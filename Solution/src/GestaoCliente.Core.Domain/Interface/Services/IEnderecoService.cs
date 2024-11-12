using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Domain.Entities;

namespace GestaoCliente.Core.Domain.Interface.Services
{
    public interface IEnderecoService
    {
        Guid? Insert(EnderecoDTORequest request);

        bool Update(Guid id, EnderecoDTORequest request);

        bool Delete(Guid id);

        List<Endereco> GetAll();

        Endereco? GetById(Guid? id);

        List<Endereco> GetByClientId(Guid ClientId);
    }
}