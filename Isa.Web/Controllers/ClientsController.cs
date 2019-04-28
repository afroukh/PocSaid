using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Isa.Core.Services.Services;

namespace Isa.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: Clients
        public ActionResult Index()
        {
            var clients = _clientService.GetClients();

            return View(clients);
           
        }
    }
}