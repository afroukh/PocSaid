using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Core.Repositories.EntityModels
{
    public class InvoiceHeader
    {
        public int InvoiceHeaderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int ClientId  { get; set; }
        public Client Client { get; set; }
        public virtual List<InvoiceItem> InvoiceItems { get; set; }

        public InvoiceHeader()
        {
            InvoiceItems = new List<InvoiceItem>();
        }
    }
}
