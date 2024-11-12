using AutoMapper;
using GestaoCliente.Core.Domain.DTOs.Requests;
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
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IClienteService clienteService, IMapper mapper)
        {
            _logger = logger;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var clientes = _clienteService.GetAll();

            return View(clientes);
        }

        public IActionResult Cadastrar()
        {
            return View(new ClienteViewModel());
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var guid = _clienteService.Insert(_mapper.Map<ClienteDTORequest>(model));

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(model);
            }
        }
    }
}