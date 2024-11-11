using AutoMapper;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Application.Helpers
{
    public static class AutoMapperHelper
    {
        public static void ConfigurationMap(this IMapperConfigurationExpression config)
        {
            config.AutoMapperClienteRequest();
        }

        public static void AutoMapperClienteRequest(this IMapperConfigurationExpression config)
        {
            config.CreateMap<IClienteRequest, Cliente>();
        }
    }
}