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
                               includes: x => x.InvoiceItems);
            var client = _unitOfWork.ClientRepository.GetFirstOrDefault(x => x.InvoiceHeaderId == id);
            return new Invoice
            {
                InvoiceHeader = invoiceHeader,
                Client = client
            };
        }

        public void AddNewInvoice(Invoice invoice)
        {
            var invoiceHeader = invoice.InvoiceHeader;
            var client = invoice.Client;

            _unitOfWork.BeginTransaction();

            foreach(var item in invoice.InvoiceHeader.InvoiceItems)
            {
                _unitOfWork.InvoiceItemRepository.Insert(item);
            }

            _unitOfWork.InvoiceHeaderRepository.Insert(invoice.InvoiceHeader);

            _unitOfWork.ClientRepository.Insert(client);

        }

    }
}
