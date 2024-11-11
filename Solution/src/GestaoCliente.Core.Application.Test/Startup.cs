using GestaoCliente.Infra.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.DependencyInjection;

namespace GestaoCliente.Core.Application.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Certifique-se de que o arquivo esteja na raiz do projeto
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            services.AddRepository(config);
            services.AddService();
        }

        public void Configure(ITestOutputHelperAccessor accessor)
        {
            // Essa parte é opcional, usada para configurar o acesso ao `ITestOutputHelper`
        }
    }
}
