using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace GestaoCliente.Infra.Data
{
    public partial class DbGestaoCliente
    {
        public void SeedDatabase()
        {
            var context = this;

            context.Database.Migrate();

            if (!context.Clientes.Any())
            {
                // carga inicial banco teste
                //context.TiposLogradouros.AddRange(
                //    new TiposLogradouro { Id = 1, Nome = "Rua", Ativo = true },
                //    new TiposLogradouro { Id = 2, Nome = "Avenida", Ativo = true },
                //    new TiposLogradouro { Id = 3, Nome = "Pra�a", Ativo = true },
                //    new TiposLogradouro { Id = 4, Nome = "Alameda", Ativo = true },
                //    new TiposLogradouro { Id = 5, Nome = "Travessa", Ativo = true },
                //    new TiposLogradouro { Id = 6, Nome = "Estrada", Ativo = true },
                //    new TiposLogradouro { Id = 7, Nome = "Rodovia", Ativo = true },
                //    new TiposLogradouro { Id = 8, Nome = "Largo", Ativo = true },
                //    new TiposLogradouro { Id = 9, Nome = "Vila", Ativo = true },
                //    new TiposLogradouro { Id = 10, Nome = "Beco", Ativo = true },
                //    new TiposLogradouro { Id = 11, Nome = "Quadra", Ativo = true },
                //    new TiposLogradouro { Id = 12, Nome = "Servid�o", Ativo = true }
                //);

                // Criando clientes
                var cliente1 = new Cliente { Nome = "Jo�o", Email = "joao@example.com" };
                var cliente2 = new Cliente { Nome = "Maria", Email = "maria@example.com" };
                var cliente3 = new Cliente { Nome = "Pedro", Email = "pedro@example.com" };

                context.Clientes.AddRange(cliente1, cliente2, cliente3);

                // Criando endere�os para cada cliente
                var endereco1 = new Endereco
                {
                    Logradouro = "Rua das Flores",
                    Numero = "123",
                    Apelido = "Casa do Jo�o",
                    LogradouroId = 1, // Refer�ncia a um tipo de logradouro existente
                    ClienteId = cliente1.Id
                };

                var endereco2 = new Endereco
                {
                    Logradouro = "Avenida Paulista",
                    Numero = "200",
                    Apelido = "Escrit�rio da Maria",
                    LogradouroId = 2,
                    ClienteId = cliente2.Id
                };

                var endereco3 = new Endereco
                {
                    Logradouro = "Pra�a da S�",
                    Numero = "1",
                    Apelido = "Casa do Pedro",
                    LogradouroId = 3,
                    ClienteId = cliente3.Id
                };

                var endereco4 = new Endereco
                {
                    Logradouro = "Travessa do Com�rcio",
                    Numero = "50",
                    Apelido = "Casa do Jo�o na praia",
                    LogradouroId = 5,
                    ClienteId = cliente1.Id
                };

                // Adicionando os endere�os ao contexto
                context.Enderecos.AddRange(endereco1, endereco2, endereco3, endereco4);

                // Salvando as mudan�as no banco de dados em mem�ria
                context.SaveChanges();
            }
        }

        private partial void InitializePartial()
        {
        }

        private partial void DisposePartial(bool disposing)
        {
        }

        private partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }

        private static partial void OnCreateModelPartial(ModelBuilder modelBuilder, string schema)
        {
        }
    }
}