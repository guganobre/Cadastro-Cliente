using GestaoCliente.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data.Configurations
{
    internal partial class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        private partial void InitializePartial(EntityTypeBuilder<Endereco> builder)
        {
        }
    }
}