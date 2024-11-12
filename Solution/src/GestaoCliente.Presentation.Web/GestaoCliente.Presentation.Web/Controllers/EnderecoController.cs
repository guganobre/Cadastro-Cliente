using AutoMapper;
using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Application.Services;
using GestaoCliente.Core.Domain.DTOs.Requests;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.Services;
using GestaoCliente.Presentation.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GestaoCliente.Presentation.Web.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEnderecoService _service;
        private readonly IClienteService _clienteService;
        private readonly ITiposLogradouroService _tiposLogradouroService;
        private readonly IMapper _mapper;

        public EnderecoController(ILogger<HomeController> logger,
            IEnderecoService service,
            IClienteService clienteService,
            ITiposLogradouroService tiposLogradouroService,
            IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _clienteService = clienteService;
            _tiposLogradouroService = tiposLogradouroService;
            _mapper = mapper;
        }

        public IActionResult Pesquisar(Guid id)
        {
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }

            if (TempData["Error"] != null)
            {
                ViewBag.Error = TempData["Error"];
            }

            var cliente = _clienteService.GetById(id);
            if (cliente == null)
            {
                TempData["Error"] = "Não foi possível encontrar o cliente";
                return ReturnPaginaInicial();
            }

            ViewData["Title"] = $"Endereços do cliente - {cliente.Nome}";

            HttpContext.Session.SetString("clienteId", id.ToString());

            var enderecos = _service.GetByClientId(id);

            return View(enderecos);
        }

        public IActionResult Cadastrar()
        {
            ViewBag.TiposLogradouros = _tiposLogradouroService.GetIsActive().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            }).ToList();

            Guid.TryParse(HttpContext.Session.GetString("clienteId"), out Guid clienteId);
            if (clienteId == Guid.Empty)
            {
                TempData["Error"] = "Não foi possível encontrar o cliente";
                return ReturnPaginaInicial();
            }

            ViewBag.ClienteId = clienteId;

            return View(new EnderecoViewModel());
        }

        [HttpPost]
        public IActionResult Cadastrar(EnderecoViewModel model)
        {
            Guid.TryParse(HttpContext.Session.GetString("clienteId"), out Guid clienteId);

            if (clienteId == Guid.Empty)
            {
                TempData["Error"] = "Não foi possível encontrar o cliente";
                return ReturnPaginaInicial();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var request = _mapper.Map<EnderecoDTORequest>(model);
                    request.ClienteId = clienteId;

                    var guid = _service.Insert(request);

                    TempData["Success"] = "Endereço criado com sucesso!";
                    return RedirectPesquisar(clienteId);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.TiposLogradouros = _tiposLogradouroService.GetIsActive().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nome
                }).ToList();

                ViewBag.ClienteId = HttpContext.Session.GetString("clienteId");
                ViewBag.Error = ex.Message;

                return View(model);
            }
        }

        public IActionResult Editar(Guid id)
        {
            var endereco = _service.GetById(id);

            if (endereco == null)
            {
                Guid.TryParse(HttpContext.Session.GetString("clienteId"), out Guid clienteId);
                if (clienteId == Guid.Empty)
                {
                    TempData["Error"] = "Não foi possível encontrar o cliente";
                    return ReturnPaginaInicial();
                }

                TempData["Error"] = "Não foi possível encontrar o endereço";
                return RedirectPesquisar(clienteId);
            }

            ViewBag.TiposLogradouros = _tiposLogradouroService.GetIsActive().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            }).ToList();

            ViewBag.ClienteId = endereco.ClienteId;

            return View(_mapper.Map<EnderecoViewModel>(endereco));
        }

        [HttpPost]
        public IActionResult Editar(Guid id, EnderecoViewModel model)
        {
            Guid.TryParse(HttpContext.Session.GetString("clienteId"), out Guid clienteId);

            if (clienteId == Guid.Empty)
            {
                TempData["Error"] = "Não foi possível encontrar o cliente";
                return ReturnPaginaInicial();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var request = _mapper.Map<EnderecoDTORequest>(model);
                    request.ClienteId = clienteId;

                    var result = _service.Update(id, request);

                    TempData["Success"] = "Endereço editado com sucesso!";
                    return RedirectPesquisar(clienteId);
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
            Guid.TryParse(HttpContext.Session.GetString("clienteId"), out Guid clienteId);
            if (clienteId == Guid.Empty)
            {
                TempData["Error"] = "Não foi possível encontrar o cliente";
                return ReturnPaginaInicial();
            }

            try
            {
                // Código para excluir o cliente
                var result = _service.Delete(id);
                if (result)
                {
                    TempData["Success"] = "Cliente excluido com sucesso!";
                }
                else
                {
                    TempData["Error"] = "Não foi possível excluir o cliente";
                }

                // Redireciona de volta para a lista de clientes ou qualquer outra página desejada
                return RedirectPesquisar(clienteId);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;

                return RedirectPesquisar(clienteId);
            }
        }

        private IActionResult RedirectPesquisar(Guid clienteId)
        {
            return RedirectToAction("Pesquisar", new { id = clienteId });
        }

        private IActionResult ReturnPaginaInicial()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}