using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Domain.Interface.Services
{
    public interface IClienteService
    {
        Guid? Insert(IClienteRequest model);

        bool Update(Guid id, IClienteRequest model);

        bool Delete(Guid id);

        List<Cliente> GetAll();

        Cliente? GetById(Guid? id);
    }
}