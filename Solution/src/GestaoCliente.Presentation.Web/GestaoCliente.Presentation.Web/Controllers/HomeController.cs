using GestaoCliente.Core.Domain.Interface.Services;
using GestaoCliente.Presentation.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestaoCliente.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClienteService _clienteService;

        public HomeController(ILogger<HomeController> logger, IClienteService clienteService)
        {
            _logger = logger;
            this._clienteService = clienteService;
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.GetAll();

            return View(clientes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}