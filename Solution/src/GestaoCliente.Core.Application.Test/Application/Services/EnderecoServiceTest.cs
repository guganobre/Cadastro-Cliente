using ExpectedObjects;
using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Exceptions;
using GestaoCliente.Core.Domain.Interface.Services;
using GestaoCliente.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Application.Test.Application.Services
{
    public class EnderecoServiceTest : BaseServiceTest
    {
        private readonly IEnderecoService service;
        private readonly IClienteService clienteService;

        public EnderecoServiceTest(IEnderecoService service,
                                    IClienteService clienteService,
                                    DbGestaoCliente db) : base(db)
        {
            this.service = service;
            this.clienteService = clienteService;
        }

        [Fact]
        public void Listar()
        {
            var result = service.GetAll();

            Assert.NotNull(result);

            Assert.True(result.Any(), "Não foi possível listar os endereço");
        }

        [Fact]
        public void Insert()
        {
            var clientId = this.clienteService.GetAll().Select(o => o.Id).First();
            var request = new EnderecoDTORequest
            {
                ClienteId = clientId,
                LogradouroId = 1,
                Apelido = "Teste",
                Logradouro = "Rua Teste",
                Complemento = "Com",
                Numero = "2",
            };

            var result = service.Insert(request);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("b7a02602-1141-4756-95b3-12da8cee6c45")]
        public void Insert_ValidIdCliente(Guid ClientId)
        {
            var request = new EnderecoDTORequest
            {
                ClienteId = ClientId,
                LogradouroId = 1,
                Apelido = "Teste",
                Logradouro = "Rua teste",
                Complemento = "Com",
                Numero = "2",
            };

            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.ClienteId);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("max")]
        public void Insert_ValidLogradouro(string logradouro)
        {
            var clientId = this.clienteService.GetAll().Select(o => o.Id).LastOrDefault();
            var request = new EnderecoDTORequest
            {
                ClienteId = clientId,
                LogradouroId = 1,
                Apelido = "Teste",
                Logradouro = (logradouro == "max") ? generateRandomString(501) : logradouro,
                Complemento = "Com",
                Numero = "2",
            };

            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.EnderecoLogradouro);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("max")]
        public void Insert_ValidApelido(string apelido)
        {
            var clientId = this.clienteService.GetAll().Select(o => o.Id).LastOrDefault();
            var request = new EnderecoDTORequest
            {
                ClienteId = clientId,
                LogradouroId = 1,
                Apelido = (apelido == "max") ? generateRandomString(51) : apelido,
                Logradouro = "Rua teste",
                Complemento = "Com",
                Numero = "2",
            };

            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.EnderecoApelido);
        }

        [Fact]
        public void Insert_ValidNumero()
        {
            var clientId = this.clienteService.GetAll().Select(o => o.Id).LastOrDefault();
            var request = new EnderecoDTORequest
            {
                ClienteId = clientId,
                LogradouroId = 1,
                Apelido = "Apelido",
                Logradouro = "Rua teste",
                Complemento = "Com",
                Numero = generateRandomString(11),
            };

            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.EnderecoNumero);
        }

        [Fact]
        public void Insert_ValidComplemento()
        {
            var clientId = this.clienteService.GetAll().Select(o => o.Id).LastOrDefault();
            var request = new EnderecoDTORequest
            {
                ClienteId = clientId,
                LogradouroId = 1,
                Apelido = "Apelido",
                Logradouro = "Rua teste",
                Complemento = generateRandomString(256),
                Numero = "1",
            };

            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.EnderecoComplemento);
        }

        [Fact]
        public void Update()
        {
            var model = service.GetAll().First();
            var request = new EnderecoDTORequest
            {
                ClienteId = model.ClienteId,
                LogradouroId = 1,
                Apelido = "Teste",
                Logradouro = "Rua Teste",
                Complemento = "Com",
                Numero = "2",
            };

            var result = service.Update(model.Id, request);

            Assert.True(result, "Não foi possivel atualizar o cliente");

            if (result)
            {
                var modelUpdate = service.GetById(model.Id);

                Assert.True(request.LogradouroId == modelUpdate.LogradouroId, "Não foi possível atualizar o Tipo do logradouro.");
                Assert.True(request.Apelido == modelUpdate.Apelido, "Não foi possível atualizar o apelido.");
                Assert.True(request.Logradouro == modelUpdate.Logradouro, "Não foi possível atualizar o logradouro.");
                Assert.True(request.Complemento == modelUpdate.Complemento, "Não foi possível atualizar o Complemento.");
                Assert.True(request.Numero == modelUpdate.Numero, "Não foi possível atualizar o Complemento.");
            }
        }

        [Theory]
        [InlineData(null)]
        [InlineData("b7a02602-1141-4756-95b3-12da8cee6c45")]
        public void Update_ValidId(Guid id)
        {
            var model = service.GetAll().First();
            var request = new EnderecoDTORequest
            {
                ClienteId = model.ClienteId,
                LogradouroId = 1,
                Apelido = "Teste",
                Logradouro = "Rua teste",
                Complemento = "Com",
                Numero = "2",
            };

            Assert.Throws<ServiceException>(() => service.Update(id, request)).ValidarMensagem(TypeServiceException.EnderecoId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("b7a02602-1141-4756-95b3-12da8cee6c45")]
        public void Update_ValidIdCliente(Guid ClientId)
        {
            var model = service.GetAll().First();

            var request = new EnderecoDTORequest
            {
                ClienteId = ClientId,
                LogradouroId = 1,
                Apelido = "Teste",
                Logradouro = "Rua teste",
                Complemento = "Com",
                Numero = "2",
            };

            Assert.Throws<ServiceException>(() => service.Update(model.Id, request)).ValidarMensagem(TypeServiceException.ClienteId);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("max")]
        public void Update_ValidLogradouro(string logradouro)
        {
            var model = service.GetAll().First();
            var request = new EnderecoDTORequest
            {
                ClienteId = model.ClienteId,
                LogradouroId = 1,
                Apelido = "Teste",
                Logradouro = (logradouro == "max") ? generateRandomString(501) : logradouro,
                Complemento = "Com",
                Numero = "2",
            };

            Assert.Throws<ServiceException>(() => service.Update(model.Id, request)).ValidarMensagem(TypeServiceException.EnderecoLogradouro);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("max")]
        public void Update_ValidApelido(string apelido)
        {
            var model = service.GetAll().First();
            var request = new EnderecoDTORequest
            {
                ClienteId = model.ClienteId,
                LogradouroId = 1,
                Apelido = (apelido == "max") ? generateRandomString(51) : apelido,
                Logradouro = "Rua teste",
                Complemento = "Com",
                Numero = "2",
            };

            Assert.Throws<ServiceException>(() => service.Update(model.Id, request)).ValidarMensagem(TypeServiceException.EnderecoApelido);
        }

        [Fact]
        public void Update_ValidNumero()
        {
            var model = service.GetAll().First();
            var request = new EnderecoDTORequest
            {
                ClienteId = model.ClienteId,
                LogradouroId = 1,
                Apelido = "Apelido",
                Logradouro = "Rua teste",
                Complemento = "Com",
                Numero = generateRandomString(11),
            };

            Assert.Throws<ServiceException>(() => service.Update(model.Id, request)).ValidarMensagem(TypeServiceException.EnderecoNumero);
        }

        [Fact]
        public void Update_ValidComplemento()
        {
            var model = service.GetAll().First();
            var request = new EnderecoDTORequest
            {
                ClienteId = model.ClienteId,
                LogradouroId = 1,
                Apelido = "Apelido",
                Logradouro = "Rua teste",
                Complemento = generateRandomString(256),
                Numero = "1",
            };

            Assert.Throws<ServiceException>(() => service.Update(model.Id, request)).ValidarMensagem(TypeServiceException.EnderecoComplemento);
        }

        [Fact]
        public void Delete()
        {
            var id = service.GetAll().Select(s => s.Id).Last();
            var result = service.Delete(id);

            Assert.True(result, "Não foi possível excluir o cliente.");

            if (result)
            {
                var entity = service.GetById(id);

                Assert.True(entity == null, "O cliente não foi excluído");
            }
        }

        [Theory]
        [InlineData("b7a02602-1141-4756-95b3-12da8cee6c45")]
        public void Delete_IdIncorreto(Guid id)
        {
            Assert.Throws<ServiceException>(() => service.Delete(id)).ValidarMensagem(TypeServiceException.EnderecoId);
        }

        private string generateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return stringBuilder.ToString();
        }
    }
}