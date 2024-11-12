using GestaoCliente.Core.Domain.DTOs.Responses;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Infra.Data.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            modelBuilder.Entity<PrEnderecoInsertResponse>().HasNoKey();

            OnModelCreatingPartial(modelBuilder);
        }

        private partial void InitializePartial();

        private partial void DisposePartial(bool disposing);

        private partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private static partial void OnCreateModelPartial(ModelBuilder modelBuilder, string schema);

        // Stored Procedures
        public int PrClienteDelete(Guid? id = null)
        {
            var idParam = new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = id.GetValueOrDefault() };
            if (!id.HasValue)
                idParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            Database.ExecuteSqlRaw("EXEC @procResult = [dbo].[pr_Cliente_Delete] @id", idParam, procResultParam);

            return (int)procResultParam.Value;
        }

        // PrClienteDeleteAsync() cannot be created due to having out parameters, or is relying on the procedure result (int)

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

        public int PrClienteUpdate(Guid? id, string nome, string email)
        {
            var idParam = new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = id.GetValueOrDefault() };
            if (!id.HasValue)
                idParam.Value = DBNull.Value;

            var nomeParam = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = nome, Size = 255 };
            if (nomeParam.Value == null)
                nomeParam.Value = DBNull.Value;

            var emailParam = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = email, Size = 255 };
            if (emailParam.Value == null)
                emailParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            Database.ExecuteSqlRaw("EXEC @procResult = [dbo].[pr_Cliente_Update] @id, @nome, @email", idParam, nomeParam, emailParam, procResultParam);

            return (int)procResultParam.Value;
        }

        // PrClienteUpdateAsync() cannot be created due to having out parameters, or is relying on the procedure result (int)

        public int PrEnderecoDelete(Guid? id = null)
        {
            var idParam = new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = id.GetValueOrDefault() };
            if (!id.HasValue)
                idParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            Database.ExecuteSqlRaw("EXEC @procResult = [dbo].[pr_Endereco_Delete] @id", idParam, procResultParam);

            return (int)procResultParam.Value;
        }

        // PrEnderecoDeleteAsync() cannot be created due to having out parameters, or is relying on the procedure result (int)

        public List<PrEnderecoInsertResponse> PrEnderecoInsert(string logradouro, string numero, string complemento, string apelido, int? logradouroId = null, Guid? clienteId = null)
        {
            int procResult;
            return PrEnderecoInsert(logradouro, numero, complemento, apelido, logradouroId, clienteId, out procResult);
        }

        public List<PrEnderecoInsertResponse> PrEnderecoInsert(string logradouro, string numero, string complemento, string apelido, int? logradouroId, Guid? clienteId, out int procResult)
        {
            var logradouroParam = new SqlParameter { ParameterName = "@logradouro", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = logradouro, Size = 500 };
            if (logradouroParam.Value == null)
                logradouroParam.Value = DBNull.Value;

            var numeroParam = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = numero, Size = 10 };
            if (numeroParam.Value == null)
                numeroParam.Value = DBNull.Value;

            var complementoParam = new SqlParameter { ParameterName = "@complemento", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = complemento, Size = 255 };
            if (complementoParam.Value == null)
                complementoParam.Value = DBNull.Value;

            var apelidoParam = new SqlParameter { ParameterName = "@apelido", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = apelido, Size = 50 };
            if (apelidoParam.Value == null)
                apelidoParam.Value = DBNull.Value;

            var logradouroIdParam = new SqlParameter { ParameterName = "@logradouroId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = logradouroId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!logradouroId.HasValue)
                logradouroIdParam.Value = DBNull.Value;

            var clienteIdParam = new SqlParameter { ParameterName = "@clienteId", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = clienteId.GetValueOrDefault() };
            if (!clienteId.HasValue)
                clienteIdParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            const string sqlCommand = "EXEC @procResult = [dbo].[pr_Endereco_Insert] @logradouro, @numero, @complemento, @apelido, @logradouroId, @clienteId";
            var procResultData = Set<PrEnderecoInsertResponse>()
                .FromSqlRaw(sqlCommand, logradouroParam, numeroParam, complementoParam, apelidoParam, logradouroIdParam, clienteIdParam, procResultParam)
                .ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async Task<List<PrEnderecoInsertResponse>> PrEnderecoInsertAsync(string logradouro, string numero, string complemento, string apelido, int? logradouroId = null, Guid? clienteId = null)
        {
            var logradouroParam = new SqlParameter { ParameterName = "@logradouro", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = logradouro, Size = 500 };
            if (logradouroParam.Value == null)
                logradouroParam.Value = DBNull.Value;

            var numeroParam = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = numero, Size = 10 };
            if (numeroParam.Value == null)
                numeroParam.Value = DBNull.Value;

            var complementoParam = new SqlParameter { ParameterName = "@complemento", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = complemento, Size = 255 };
            if (complementoParam.Value == null)
                complementoParam.Value = DBNull.Value;

            var apelidoParam = new SqlParameter { ParameterName = "@apelido", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = apelido, Size = 50 };
            if (apelidoParam.Value == null)
                apelidoParam.Value = DBNull.Value;

            var logradouroIdParam = new SqlParameter { ParameterName = "@logradouroId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = logradouroId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!logradouroId.HasValue)
                logradouroIdParam.Value = DBNull.Value;

            var clienteIdParam = new SqlParameter { ParameterName = "@clienteId", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = clienteId.GetValueOrDefault() };
            if (!clienteId.HasValue)
                clienteIdParam.Value = DBNull.Value;

            const string sqlCommand = "EXEC [dbo].[pr_Endereco_Insert] @logradouro, @numero, @complemento, @apelido, @logradouroId, @clienteId";
            var procResultData = await Set<PrEnderecoInsertResponse>()
                .FromSqlRaw(sqlCommand, logradouroParam, numeroParam, complementoParam, apelidoParam, logradouroIdParam, clienteIdParam)
                .ToListAsync();

            return procResultData;
        }

        public int PrEnderecoUpdate(Guid? id, string logradouro, string numero, string complemento, string apelido, int? logradouroId = null, Guid? clienteId = null)
        {
            var idParam = new SqlParameter { ParameterName = "@id", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = id.GetValueOrDefault() };
            if (!id.HasValue)
                idParam.Value = DBNull.Value;

            var logradouroParam = new SqlParameter { ParameterName = "@logradouro", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = logradouro, Size = 500 };
            if (logradouroParam.Value == null)
                logradouroParam.Value = DBNull.Value;

            var numeroParam = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = numero, Size = 10 };
            if (numeroParam.Value == null)
                numeroParam.Value = DBNull.Value;

            var complementoParam = new SqlParameter { ParameterName = "@complemento", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = complemento, Size = 255 };
            if (complementoParam.Value == null)
                complementoParam.Value = DBNull.Value;

            var apelidoParam = new SqlParameter { ParameterName = "@apelido", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Input, Value = apelido, Size = 50 };
            if (apelidoParam.Value == null)
                apelidoParam.Value = DBNull.Value;

            var logradouroIdParam = new SqlParameter { ParameterName = "@logradouroId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Input, Value = logradouroId.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!logradouroId.HasValue)
                logradouroIdParam.Value = DBNull.Value;

            var clienteIdParam = new SqlParameter { ParameterName = "@clienteId", SqlDbType = SqlDbType.UniqueIdentifier, Direction = ParameterDirection.Input, Value = clienteId.GetValueOrDefault() };
            if (!clienteId.HasValue)
                clienteIdParam.Value = DBNull.Value;

            var procResultParam = new SqlParameter { ParameterName = "@procResult", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            Database.ExecuteSqlRaw("EXEC @procResult = [dbo].[pr_Endereco_Update] @id, @logradouro, @numero, @complemento, @apelido, @logradouroId, @clienteId", idParam, logradouroParam, numeroParam, complementoParam, apelidoParam, logradouroIdParam, clienteIdParam, procResultParam);

            return (int)procResultParam.Value;
        }

        // PrEnderecoUpdateAsync() cannot be created due to having out parameters, or is relying on the procedure result (int)
    }
}