using GestaoCliente.Core.Application.Services;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Infra.IoC
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddService(this IServiceCollection service)
        {
            service.AddScoped<ITiposLogradouroService, TiposLogradouroService>();

            return service;
        }
    }
}
