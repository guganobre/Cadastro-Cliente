using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.Repositories;

namespace GestaoCliente.Infra.Data.Repositories
{
    public class ClienteRepository : BaseListRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbGestaoCliente dbContext) : base(dbContext)
        {
        }

        public Guid? Add(Cliente cliente)
        {
            try
            {
                var result = _dbContext.PrClienteInsert(cliente.Nome, cliente.Email);

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
                var result = _dbContext.PrClienteDelete(id);

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Exists(Guid id) => Exists(o => o.Id == id);

        public bool Update(Cliente cliente)
        {
            try
            {
                var result = _dbContext.PrClienteUpdate(cliente.Id, cliente.Nome, cliente.Email);

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}