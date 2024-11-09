using GestaoCliente.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data
{
    // Clientes
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_Clientes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName(@"Nome").HasColumnType("varchar(255)").IsRequired(false).IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("varchar(255)").IsRequired().IsUnicode(false).HasMaxLength(255);

            builder.HasIndex(x => x.Email).HasDatabaseName("UQ_Cliente_Email").IsUnique();
        }
    }
}