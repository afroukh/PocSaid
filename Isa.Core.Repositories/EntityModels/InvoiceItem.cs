namespace Isa.Core.Repositories.EntityModels
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int ProductId { get; set; }
        public int InvoiceHeaderId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; }
    }
}