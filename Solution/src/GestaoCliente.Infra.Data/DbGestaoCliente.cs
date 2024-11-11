using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.DTOs;
using GestaoCliente.Infra.Data.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlTypes;

namespace GestaoCliente.Infra.Data
{
    public partial class DbGestaoCliente : DbContext
    {
        public DbGestaoCliente()
        {
            InitializePartial();
        }

        public DbGestaoCliente(DbContextOptions<DbGestaoCliente> options)
            : base(options)
        {
            InitializePartial();
        }

        public DbSet<Cliente> Clientes { get; set; } // Clientes
        public DbSet<Endereco> Enderecos { get; set; } // Enderecos
        public DbSet<TiposLogradouro> TiposLogradouros { get; set; } // TiposLogradouro

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:localhost;Initial Catalog=GestaoCliente;Persist Security Info=False;User ID=sa;Password=Guga@4802;TrustServerCertificate=True;");
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
            modelBuilder.ApplyConfiguration(new TiposLogradouroConfiguration());

            modelBuilder.Entity<PrClienteInsertResponse>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        private partial void InitializePartial();

        private partial void DisposePartial(bool disposing);

        private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private static partial void OnCreateModelPartial(ModelBuilder modelBuilder, string schema);

        // Stored Procedures
        public List<PrClienteInsertResponse> PrClienteInsert(string nome, string email)
        {
            int procResult;
            return PrClienteInsert(nome, email, out procResult);
        }

        public List<PrClienteInsertResponse> PrClienteInsert(string nome, string email, out int procResult)
        {
            var nomeParam = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = nome, Size = 255 };
            if (nomeParam.Value == null)
                nomeParam.Value = DBNull.Value;

            var emailParam = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = email, Size = 255 };
            if (emailParam.Value == null)
                emailParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            const string sqlCommand = "EXEC @procResult = [dbo].[pr_Cliente_Insert] @nome, @email";
            var procResultData = Set<PrClienteInsertResponse>()
                .FromSqlRaw(sqlCommand, nomeParam, emailParam, procResultParam)
                .ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async Task<List<PrClienteInsertResponse>> PrClienteInsertAsync(string nome, string email)
        {
            var nomeParam = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = nome, Size = 255 };
            if (nomeParam.Value == null)
                nomeParam.Value = DBNull.Value;

            var emailParam = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = email, Size = 255 };
            if (emailParam.Value == null)
                emailParam.Value = DBNull.Value;

            const string sqlCommand = "EXEC [dbo].[pr_Cliente_Insert] @nome, @email";
            var procResultData = await Set<PrClienteInsertResponse>()
                .FromSqlRaw(sqlCommand, nomeParam, emailParam)
                .ToListAsync();

            return procResultData;
        }
    }
}