using Isa.Core.Repositories;
using Isa.Core.Repositories.EntityModels;
using Isa.Core.Repositories.Repositories;
using Isa.Infrastructures.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Infrastructures.Repositories.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        
        IRepository<InvoiceHeader> _invoiceHeaderRepository { get; set; }
        IRepository<InvoiceItem> _invoiceItemRepository { get; set; }
        IRepository<Product> _productRepository { get; set; }
        IRepository<Client> _clientRepository { get; set; }
        private ObjectContext _objectContext;
        private DbTransaction _transaction;
        private IEntitiesContext _context;
        private bool _disposed = false;

        public UnitOfWork(IEntitiesContext context)
        {
            this._context = context;
        }

        public IRepository<InvoiceHeader> InvoiceHeaderRepository
        {
            get
            {
                if (this._invoiceHeaderRepository == null)
                    this._invoiceHeaderRepository = new EntityRepository<InvoiceHeader>(_context);
                return _invoiceHeaderRepository;
            }
        }
        public IRepository<InvoiceItem> InvoiceItemRepository
        {
            get
            {
                if (this._invoiceItemRepository == null)
                    this._invoiceItemRepository = new EntityRepository<InvoiceItem>(_context);
                return _invoiceItemRepository;
            }
        }
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new EntityRepository<Product>(_context);
                return _productRepository;
            }
        }
        public IRepository<Client> ClientRepository
        {
            get
            {
                if (this._clientRepository == null)
                    this._clientRepository = new EntityRepository<Client>(_context);
                return _clientRepository;
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // free other managed objects that implement
                // IDisposable only

                try
                {
                    if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
                    {
                        _objectContext.Connection.Close();
                    }
                }
                catch (ObjectDisposedException)
                {
                    // do nothing, the objectContext has already been disposed
                }

                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }

                _transaction?.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;

        }

        public void BeginTransaction()
        {
            _objectContext = ((IObjectContextAdapter)_context).ObjectContext;
            if (_objectContext.Connection.State == ConnectionState.Open)
            {
                return;
            }
            _objectContext.Connection.Open();
            _transaction = _objectContext.Connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

    }
}
