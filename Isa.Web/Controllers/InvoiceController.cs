using Isa.Core.Repositories.EntityModels;
using Isa.Core.Services.DomainModels;
using Isa.Core.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Isa.Web.Controllers
{
    public class InvoiceController : Controller
    {

        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: Invoice
        public ActionResult Index()
        {
            return View(_invoiceService.GetInvoiceById(2));
        }


     

        public ActionResult Create()
        {
            var client = new Client
            {
                Name = "faisal",
                Address = "Montréal"
            };

            var invoiceHeader = new InvoiceHeader
            {
                Client = client,
                InvoiceDate = DateTime.Now,
            };


            var invoiceItems = new List<InvoiceItem>
            {
                new InvoiceItem
                {
                    ProductId = 2,
                    Quantity = 5
                },
                new InvoiceItem
                {
                    ProductId = 3,
                    Quantity = 22
                },
                new InvoiceItem
                {
                    ProductId = 4,
                    Quantity = 15
                }

            };

            invoiceHeader.InvoiceItems = invoiceItems;

            var invoice = new Invoice
            {
                InvoiceHeader = invoiceHeader,
                Client = client,
            };

            _invoiceService.AddNewInvoice(invoice);

            return View();
        }
    }
}