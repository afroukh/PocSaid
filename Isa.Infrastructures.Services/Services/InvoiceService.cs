using Isa.Core.Repositories;
using Isa.Core.Services.DomainModels;
using Isa.Core.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Infrastructures.Services.Services
{
    public class InvoiceService: IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Invoice GetInvoiceById(int id)
        {
            var invoiceHeader = _unitOfWork.InvoiceHeaderRepository.GetFirstOrDefault(x => x.InvoiceHeaderId == id,
                                x => x.InvoiceItems);
            var client = _unitOfWork.ClientRepository.GetFirstOrDefault(x => x.ClientId == invoiceHeader.ClientId);
            
            foreach(var item in invoiceHeader.InvoiceItems)
            {
                item.Product = _unitOfWork.ProductRepository.GetFirstOrDefault(x => x.ProductId == item.ProductId);
            }

            return new Invoice
            {
                InvoiceHeader = invoiceHeader,
                Client = client
            };
        }

        public void AddNewInvoice(Invoice invoice)
        {

            try
            {
                _unitOfWork.BeginTransaction();

                var invoiceHeader = invoice.InvoiceHeader;
                invoiceHeader.Client = invoice.Client;

                _unitOfWork.ClientRepository.Insert(invoice.Client);

                _unitOfWork.InvoiceHeaderRepository.Insert(invoice.InvoiceHeader);

                foreach (var item in invoice.InvoiceHeader.InvoiceItems)
                {
                    _unitOfWork.InvoiceItemRepository.Insert(item);
                }

                _unitOfWork.Commit();
                _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback();
            }
           

        }

    }
}
