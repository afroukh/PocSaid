using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Core.Repositories.EntityModels
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Label { get; set; }
        public decimal Price { get; set; }
    }
}
