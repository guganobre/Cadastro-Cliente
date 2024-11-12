using GestaoCliente.Core.Domain.DTOs.Requests;
using GestaoCliente.Core.Domain.Entities;

namespace GestaoCliente.Core.Domain.Interface.Services
{
    public interface IClienteService
    {
        Guid? Insert(ClienteDTORequest model);

        bool Update(Guid id, ClienteDTORequest model);

        bool Delete(Guid id);

        List<Cliente> GetAll();

        Cliente? GetById(Guid? id);
    }
}