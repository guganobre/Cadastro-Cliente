using GestaoCliente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Domain.Interface.Repositories
{
    public interface IClienteRepository : IBaseListRepository<Cliente>
    {
        bool Exists(Guid id);

        Guid? Add(Cliente cliente);

        bool Delete(Guid id);

        bool Update(Cliente cliente);
    }
}