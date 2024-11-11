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
    }
}