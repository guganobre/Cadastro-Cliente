using GestaoCliente.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoCliente.Infra.Data.Configurations
{
    // Enderecos
    internal partial class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos", "dbo").HasComment("Tabela para armazenar os logradouros dos clientes");
            builder.HasKey(x => x.Id).HasName("Pk_Enderecos").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedOnAdd().HasDefaultValueSql("newid()").HasComment(@"Chave da tabela endereço");
            builder.Property(x => x.Logradouro).HasColumnName(@"Logradouro").HasColumnType("varchar(500)").IsRequired().IsUnicode(false).HasMaxLength(500).HasComment(@"Campo com o detalhe/nome do logradouro");
            builder.Property(x => x.Numero).HasColumnName(@"Numero").HasColumnType("varchar(10)").IsRequired(false).IsUnicode(false).HasMaxLength(10).HasComment(@"Numero do endereço");
            builder.Property(x => x.Complemento).HasColumnName(@"Complemento").HasColumnType("varchar(255)").IsRequired(false).IsUnicode(false).HasMaxLength(255).HasComment(@"Campo descritivo para detalhar o endereço");
            builder.Property(x => x.Apelido).HasColumnName(@"Apelido").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50).HasComment(@"Apelido identificador via sistema do enderço");
            builder.Property(x => x.LogradouroId).HasColumnName(@"LogradouroId").HasColumnType("int").IsRequired().HasComment(@"Chave da tabela tipo logradouro");
            builder.Property(x => x.ClienteId).HasColumnName(@"ClienteId").HasColumnType("uniqueidentifier").IsRequired().HasComment(@"Chave da tabela Cliente");

            // Foreign keys
            builder.HasOne(a => a.Cliente).WithMany(b => b.Enderecos).HasForeignKey(c => c.ClienteId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Clientes_Enderecos");
            builder.HasOne(a => a.TiposLogradouro).WithMany(b => b.Enderecos).HasForeignKey(c => c.LogradouroId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_TiposLogradouro_Enderecos");

            builder.HasIndex(x => x.ClienteId).HasDatabaseName("IX_Enderecos_ClienteId");
            builder.HasIndex(x => x.LogradouroId).HasDatabaseName("IX_Enderecos_LogradouroId");

            InitializePartial(builder);
        }

        private partial void InitializePartial(EntityTypeBuilder<Endereco> builder);
    }
}