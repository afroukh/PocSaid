using Isa.Core.Repositories.EntityModels;
using Isa.Core.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Core.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<InvoiceHeader> InvoiceHeaderRepository { get; }
        IRepository<InvoiceItem> InvoiceItemRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Client> ClientRepository { get; }

        void SaveChanges();
        void Dispose();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
