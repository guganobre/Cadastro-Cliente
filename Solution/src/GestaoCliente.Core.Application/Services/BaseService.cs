using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Application.Services
{
    public class BaseService
    {
        private readonly IMapper mapper;

        public BaseService()
        {
            this.mapper = mapper;
        }
    }
}