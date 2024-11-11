﻿using GestaoCliente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Domain.Interface.Repositories
{
    public interface IClienteRepository : IBaseListRepository<Cliente>
    {
        Guid? Add(Cliente cliente);
    }
}