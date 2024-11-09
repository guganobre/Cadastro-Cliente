using GestaoCliente.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data
{
    // Enderecos
    internal class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos", "dbo");
            builder.HasKey(x => x.Id).HasName("Pk_Enderecos").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName(@"Nome").HasColumnType("varchar(500)").IsRequired().IsUnicode(false).HasMaxLength(500);
            builder.Property(x => x.Numero).HasColumnName(@"Numero").HasColumnType("varchar(10)").IsRequired(false).IsUnicode(false).HasMaxLength(10);
            builder.Property(x => x.Complemento).HasColumnName(@"Complemento").HasColumnType("varchar(255)").IsRequired(false).IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.Apelido).HasColumnName(@"Apelido").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.LogradouroId).HasColumnName(@"LogradouroId").HasColumnType("int").IsRequired();
            builder.Property(x => x.ClienteId).HasColumnName(@"ClienteId").HasColumnType("uniqueidentifier").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.Cliente).WithMany(b => b.Enderecos).HasForeignKey(c => c.ClienteId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Clientes_Enderecos");
            builder.HasOne(a => a.Logradouro).WithMany(b => b.Enderecos).HasForeignKey(c => c.LogradouroId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Logradouros_Enderecos");
        }
    }
}