using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using GestaoCliente.Infra.Data.Configurations;
using GestaoCliente.Infra.Data.Repositories;
using GestaoCliente.Infra.Data;
using GestaoCliente.Core.Domain.Interface.Repositories;

namespace GestaoCliente.Infra.IoC
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbGestaoCliente>(options => options.UseSqlServer(configuration.GetConnectionString("SQLConnection"), b => b.MigrationsAssembly(typeof(DbGestaoCliente).Assembly.FullName)));

            services.AddScoped<DbGestaoCliente>();
            services.AddScoped(typeof(IBaseListRepository<>), typeof(BaseListRepository<>));

            return services;
        }


    }
}
