
using GestaoCliente.Core.Domain.DTOs.Responses;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data.Configurations
{
    // Clientes
    internal partial class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes", "dbo").HasComment("Armazenamento dos cliente");
            builder.HasKey(x => x.Id).HasName("Pk_Clientes").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("newid()").HasComment(@"Identificador único do cliente");
            builder.Property(x => x.Nome).HasColumnName(@"Nome").HasColumnType("varchar(255)").IsRequired(false).IsUnicode(false).HasMaxLength(255).HasComment(@"Nome do cliente");
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("varchar(255)").IsRequired().IsUnicode(false).HasMaxLength(255).HasComment(@"E-mail do cliente, campo único para cada cliente");

            builder.HasIndex(x => x.Email).HasDatabaseName("UQ_Cliente_Email").IsUnique();

            InitializePartial(builder);
        }

        private partial void InitializePartial(EntityTypeBuilder<Cliente> builder);
    }

}

