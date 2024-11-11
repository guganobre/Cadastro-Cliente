using GestaoCliente.Core.Domain.Interface.Services;

namespace GestaoCliente.Core.Application.Test.Application.Services
{
    public class TiposLogradouroServiceTest
    {
        private readonly ITiposLogradouroService service;

        public TiposLogradouroServiceTest(ITiposLogradouroService service)
        {
            this.service = service;
        }

        [Fact]
        public void Listar()
        {
            var result = service.GetAll();

            Assert.NotNull(result);
        }
    }
}