using GestaoCliente.Core.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace GestaoCliente.Infra.Data
{
    public class DbGestaoCliente : DbContext//, IDbGestaoCliente
    {
        public DbGestaoCliente()
        {
        }

        public DbGestaoCliente(DbContextOptions<DbGestaoCliente> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } // Clientes
        public DbSet<Endereco> Enderecos { get; set; } // Enderecos
        public DbSet<Logradouro> Logradouros { get; set; } // Logradouros

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:localhost;Initial Catalog=GestaoCliente;Persist Security Info=False;User ID=sa;Password=Guga@4802;");
            }
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new LogradouroConfiguration());
        }

    }
}

