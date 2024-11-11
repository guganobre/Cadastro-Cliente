using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Exceptions;
using GestaoCliente.Core.Domain.Interface;
using GestaoCliente.Core.Domain.Interface.Services;
using GestaoCliente.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Application.Test.Application.Services
{
    public class ClientServiceTest : BaseServiceTest
    {
        private readonly IClienteService service;

        public ClientServiceTest(IClienteService service, DbGestaoCliente db) : base(db)
        {
            this.service = service;
        }

        [Fact]
        public void Listar()
        {
            var result = service.GetAll();

            Assert.NotNull(result);

            Assert.True(result.Any(), "Não foi possível listar os clientes");
        }

        [Fact]
        public void Insert()
        {
            var request = new ClienteRequest
            {
                Email = $"{generateRandomString(20)}@gmail.com",
                Nome = "teste"
            };

            var result = service.Insert(request);

            Assert.NotNull(result);
        }

        [Fact]
        public void Insert_ValidEmailSize()
        {
            var request = new ClienteRequest
            {
                Email = generateRandomString(256) + "@gmail.com",
                Nome = "teste"
            };

            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.ClienteTamanhoEmail);
        }

        [Theory]
        [InlineData("lgnobre")]
        [InlineData("")]
        [InlineData(null)]
        public void Insert_ValidEmail(string email)
        {
            var request = new ClienteRequest
            {
                Email = email,
                Nome = "teste"
            };
            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.ClienteEmail);
        }

        [Fact]
        public void Insert_ValidNomeSize()
        {
            var request = new ClienteRequest
            {
                Email = "email@gmail.com",
                Nome = generateRandomString(257)
            };

            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.ClienteTamanhoNome);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Insert_ValidNome(string nome)
        {
            var request = new ClienteRequest
            {
                Email = "email@gmail.com",
                Nome = nome
            };

            Assert.Throws<ServiceException>(() => service.Insert(request)).ValidarMensagem(TypeServiceException.ClienteNome);
        }

        [Fact]
        public void Update()
        {
            var model = service.GetAll().First();
            var request = new ClienteRequest
            {
                Email = "email@confirmacao.com.br",
                Nome = "Teste Atualização"
            };

            var result = service.Update(model.Id, request);

            Assert.True(result, "Não foi possivel atualizar o cliente");

            if (result)
            {
                var modelUpdate = service.GetById(model.Id);

                Assert.True(request.Email == modelUpdate.Email, "Não foi possível atualizar o e-mail do Cliente.");
                Assert.True(request.Nome == modelUpdate.Nome, "Não foi possível atualizar o nome do Cliente.");
            }
        }

        [Theory]
        [InlineData("b7a02602-1141-4756-95b3-12da8cee6c45")]
        public void Update_IdIncorreto(Guid id)
        {
            var request = new ClienteRequest
            {
                Email = "lgnobre@gmail.com",
                Nome = "teste",
            };

            Assert.Throws<ServiceException>(() => service.Update(id, request)).ValidarMensagem(TypeServiceException.ClienteId);
        }

        [Fact]
        public void Update_ValidEmailSize()
        {
            var entity = service.GetAll().First();
            var request = new ClienteRequest
            {
                Nome = entity.Nome,
                Email = generateRandomString(256) + "@gmail.com"
            };

            Assert.Throws<ServiceException>(() => service.Update(entity.Id, request)).ValidarMensagem(TypeServiceException.ClienteTamanhoEmail);
        }

        [Theory]
        [InlineData("lgnobre")]
        [InlineData("")]
        [InlineData(null)]
        public void Update_ValidEmail(string email)
        {
            var entity = service.GetAll().First();
            var request = new ClienteRequest
            {
                Email = email,
                Nome = entity.Nome
            };

            Assert.Throws<ServiceException>(() => service.Update(entity.Id, request)).ValidarMensagem(TypeServiceException.ClienteEmail);
        }

        [Fact]
        public void Update_ValidNomeSize()
        {
            var entity = service.GetAll().First();
            var request = new ClienteRequest
            {
                Email = entity.Email,
                Nome = generateRandomString(257),
            };

            Assert.Throws<ServiceException>(() => service.Update(entity.Id, request)).ValidarMensagem(TypeServiceException.ClienteTamanhoEmail);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Update_NomeVazioOuNulo(string nome)
        {
            var entity = service.GetAll().First();
            var request = new ClienteRequest
            {
                Email = entity.Email,
                Nome = nome
            };

            Assert.Throws<ServiceException>(() => service.Update(entity.Id, request));
        }

        [Fact]
        public void Delete()
        {
            var id = service.GetAll().Select(s => s.Id).FirstOrDefault();

            var result = service.Delete(id);

            Assert.True(result, "Não foi possível excluir o cliente.");

            if (result)
            {
                var entity = service.GetById(id);

                Assert.True(entity != null, "O cliente não foi excluído");
            }
        }

        [Theory]
        [InlineData("b7a02602-1141-4756-95b3-12da8cee6c45")]
        public void Delete_IdIncorreto(Guid id)
        {
            Assert.Throws<ServiceException>(() => service.Delete(id)).ValidarMensagem(TypeServiceException.ClienteId);
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