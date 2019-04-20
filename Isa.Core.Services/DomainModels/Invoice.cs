using Isa.Core.Repositories.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Core.Services.DomainModels
{
    public class Invoice
    {
        public InvoiceHeader InvoiceHeader { get; set; }
        public Client Client { get; set; }

    }
}
