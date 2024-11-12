using GestaoCliente.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data.Configurations
{
    internal partial class TiposLogradouroConfiguration : IEntityTypeConfiguration<TiposLogradouro>
    {
        private partial void InitializePartial(EntityTypeBuilder<TiposLogradouro> builder)
        {
            builder.HasData(
                new TiposLogradouro { Id = 1, Nome = "Rua", Ativo = true },
                new TiposLogradouro { Id = 2, Nome = "Avenida", Ativo = true },
                new TiposLogradouro { Id = 3, Nome = "Praça", Ativo = true },
                new TiposLogradouro { Id = 4, Nome = "Alameda", Ativo = true },
                new TiposLogradouro { Id = 5, Nome = "Travessa", Ativo = true },
                new TiposLogradouro { Id = 6, Nome = "Estrada", Ativo = true },
                new TiposLogradouro { Id = 7, Nome = "Rodovia", Ativo = true },
                new TiposLogradouro { Id = 8, Nome = "Largo", Ativo = true },
                new TiposLogradouro { Id = 9, Nome = "Vila", Ativo = true },
                new TiposLogradouro { Id = 10, Nome = "Beco", Ativo = true },
                new TiposLogradouro { Id = 11, Nome = "Quadra", Ativo = true },
                new TiposLogradouro { Id = 12, Nome = "Servidão", Ativo = true }
            );
        }
    }
}