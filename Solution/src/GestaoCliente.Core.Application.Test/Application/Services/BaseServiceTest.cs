using GestaoCliente.Infra.Data;

namespace GestaoCliente.Core.Application.Test.Application.Services
{
    public abstract class BaseServiceTest
    {
        public BaseServiceTest(DbGestaoCliente db)
        {
            db.SeedDatabase();
        }
    }
}