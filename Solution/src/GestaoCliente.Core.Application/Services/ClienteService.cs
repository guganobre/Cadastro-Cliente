using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.DTOs.Requests;
using GestaoCliente.Core.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Application.Services
{
    public class ClienteService : IClienteService
    {
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid? Insert(IClienteRequest model)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, IClienteRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
