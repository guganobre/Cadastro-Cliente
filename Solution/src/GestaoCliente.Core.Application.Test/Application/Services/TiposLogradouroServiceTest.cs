using GestaoCliente.Core.Domain.Interface.Services;
using GestaoCliente.Infra.Data;

namespace GestaoCliente.Core.Application.Test.Application.Services
{
    public class TiposLogradouroServiceTest : BaseServiceTest
    {
        private readonly ITiposLogradouroService service;

        public TiposLogradouroServiceTest(ITiposLogradouroService service, DbGestaoCliente db)
            : base(db)
        {
            this.service = service;
        }

        [Fact]
        public void Listar()
        {
            var result = service.GetIsActive();

            Assert.NotNull(result);

            Assert.True(result.Any(), "Não foi possível listar os registros do tipo logradouro");
        }
    }
}