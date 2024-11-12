using AutoMapper;
using GestaoCliente.Core.Domain.DTOs.Requests;
using GestaoCliente.Core.Domain.Interface.Services;
using GestaoCliente.Presentation.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }

            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
            }

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

                    TempData["Success"] = "Cliente criado com sucesso!";
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

        public IActionResult Editar(Guid id)
        {
            var cliente = _clienteService.GetById(id);

            return View(_mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpPost]
        public IActionResult Editar(Guid id, ClienteViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var guid = _clienteService.Update(id, _mapper.Map<ClienteDTORequest>(model));

                    TempData["Success"] = "Cliente editado com sucesso!";
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

        public IActionResult Excluir(Guid id)
        {
            try
            {
                // Código para excluir o cliente
                var result = _clienteService.Delete(id);
                if (result)
                {
                    TempData["Success"] = "Cliente excluido com sucesso!";
                }
                else
                {
                    TempData["Error"] = "Não foi possível excluir o cliente";
                }

                // Redireciona de volta para a lista de clientes ou qualquer outra página desejada
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectToAction("Index");
            }
        }
    }
}