using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.Repositories;
using GestaoCliente.Core.Domain.Interface.Services;

namespace GestaoCliente.Core.Application.Services
{
    public class TiposLogradouroService : ITiposLogradouroService
    {
        private readonly IBaseListRepository<TiposLogradouro> repository;

        public TiposLogradouroService(IBaseListRepository<TiposLogradouro> repository)
        {
            this.repository = repository;
        }

        public List<TiposLogradouro> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
