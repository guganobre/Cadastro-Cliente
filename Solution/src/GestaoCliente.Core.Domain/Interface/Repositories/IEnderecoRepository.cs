using GestaoCliente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Domain.Interface.Repositories
{
    public interface IEnderecoRepository : IBaseListRepository<Endereco>
    {
        bool Exists(Guid id);

        Guid? Add(Endereco entity);

        bool Delete(Guid id);

        bool Update(Endereco entity);
    }
}