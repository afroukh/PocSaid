using Isa.Core.Services.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Core.Services.Services
{
    public interface IInvoiceService
    {
        void AddNewInvoice(Invoice invoice);
        Invoice GetInvoiceById(int id);
    }
}
