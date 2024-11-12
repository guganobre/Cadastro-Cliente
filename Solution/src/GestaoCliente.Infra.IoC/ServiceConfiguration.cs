using AutoMapper;
using GestaoCliente.Core.Application.Helpers;
using GestaoCliente.Core.Application.Services;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Interface.Repositories;
using GestaoCliente.Core.Domain.Interface.Services;
using GestaoCliente.Infra.Data.Repositories;
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
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ITiposLogradouroService, TiposLogradouroService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddSingleton(new MapperConfiguration(config => config.ConfigurationMap()).CreateMapper());

            return services;
        }
    }
}