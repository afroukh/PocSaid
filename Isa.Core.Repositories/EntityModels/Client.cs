using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Core.Repositories.EntityModels
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual List<InvoiceHeader>  InvoiceHeaders { get; set; }

        public Client()
        {
            InvoiceHeaders = new List<InvoiceHeader>();
        }
    }
}
