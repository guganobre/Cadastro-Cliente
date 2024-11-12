
using GestaoCliente.Core.Domain.DTOs.Responses;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data.Configurations
{
    // TiposLogradouro
    internal partial class TiposLogradouroConfiguration : IEntityTypeConfiguration<TiposLogradouro>
    {
        public void Configure(EntityTypeBuilder<TiposLogradouro> builder)
        {
            builder.ToTable("TiposLogradouro", "dbo").HasComment("Tipos de logradouros para cadastro de endereço");
            builder.HasKey(x => x.Id).HasName("Pk_Logradouros").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn().HasComment(@"Chave da tabela tipo logradouro");
            builder.Property(x => x.Nome).HasColumnName(@"Nome").HasColumnType("varchar(50)").IsRequired(false).IsUnicode(false).HasMaxLength(50).HasComment(@"Nome identificador do tipo logradouro");
            builder.Property(x => x.Ativo).HasColumnName(@"Ativo").HasColumnType("bit").IsRequired().HasComment(@"Status do tipo logradouro");

            builder.HasIndex(x => x.Nome).HasDatabaseName("UQ_Logradouros_Nome").IsUnique();

            InitializePartial(builder);
        }

        private partial void InitializePartial(EntityTypeBuilder<TiposLogradouro> builder);
    }

}

