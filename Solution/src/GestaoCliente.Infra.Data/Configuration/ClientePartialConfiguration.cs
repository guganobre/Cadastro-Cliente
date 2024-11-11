using GestaoCliente.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data.Configurations
{
    internal partial class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        private partial void InitializePartial(EntityTypeBuilder<Cliente> builder)
        {
        }
    }
}