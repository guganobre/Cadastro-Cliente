using GestaoCliente.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data
{
    // Logradouros
    internal class LogradouroConfiguration : IEntityTypeConfiguration<Logradouro>
    {
        public void Configure(EntityTypeBuilder<Logradouro> builder)
        {
            builder.ToTable("Logradouros", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_Logradouros").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Nome).HasColumnName(@"Nome").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.Ativo).HasColumnName(@"Ativo").HasColumnType("bit").IsRequired();

            builder.HasIndex(x => x.Nome).HasDatabaseName("UQ_Logradouros_Nome").IsUnique();
        }
    }
}