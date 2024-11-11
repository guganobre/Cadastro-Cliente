using GestaoCliente.Core.Domain.Entities;

namespace GestaoCliente.Core.Domain.Interface.Services
{
    public interface ITiposLogradouroService
    {
        List<TiposLogradouro> GetAll();
    }
}