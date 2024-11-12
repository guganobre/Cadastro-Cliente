using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Infra.Data.Repositories
{
    public class EnderecoRepository : BaseListRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DbGestaoCliente dbContext) : base(dbContext)
        {
        }

        public Guid? Add(Endereco entity)
        {
            try
            {
                var result = _dbContext.PrEnderecoInsert(
                                            entity.Logradouro,
                                            entity.Numero,
                                            entity.Complemento,
                                            entity.Apelido,
                                            entity.LogradouroId,
                                            entity.ClienteId);

                return result?.First().Id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var result = _dbContext.PrEnderecoDelete(id);

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Exists(Guid id) => Get(w => w.Id == id).Any();

        public bool Update(Endereco entity)
        {
            try
            {
                var result = _dbContext.PrEnderecoUpdate(
                                            entity.Id,
                                            entity.Logradouro,
                                            entity.Numero,
                                            entity.Complemento,
                                            entity.Apelido,
                                            entity.LogradouroId,
                                            entity.ClienteId);

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}