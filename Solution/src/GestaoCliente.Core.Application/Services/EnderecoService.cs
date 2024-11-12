using AutoMapper;
using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Application.Validators;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Exceptions;
using GestaoCliente.Core.Domain.Interface.Repositories;
using GestaoCliente.Core.Domain.Interface.Services;

namespace GestaoCliente.Core.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository repository;
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public EnderecoService(IEnderecoRepository repository,
            IClienteRepository clienteRepository,
            IMapper mapper)
        {
            this.repository = repository;
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public bool Delete(Guid id)
        {
            var exists = repository.Exists(id);
            if (!exists)
            {
                throw new ServiceException(TypeServiceException.EnderecoId);
            }

            return repository.Delete(id);
        }

        public List<Endereco> GetAll() => repository.Get().ToList();

        public List<Endereco> GetByClientId(Guid ClientId)
        {
            throw new NotImplementedException();
        }

        public Endereco? GetById(Guid? id) => repository.Get(w => w.Id == id).FirstOrDefault();

        public Guid? Insert(EnderecoDTORequest request)
        {
            var validator = new EnderecoDTORequestValidator();

            var result = validator.Validate(request);
            if (result.IsValid)
            {
                var exists = clienteRepository.Exists(request.ClienteId);
                if (!exists)
                {
                    throw new ServiceException(TypeServiceException.ClienteId);
                }

                return repository.Add(mapper.Map<Endereco>(request));
            }
            else
            {
                throw new ServiceException(result.Errors.First().ErrorMessage);
            }
        }

        public bool Update(Guid id, EnderecoDTORequest request)
        {
            var validator = new EnderecoDTORequestValidator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                if (!repository.Exists(id))
                {
                    throw new ServiceException(TypeServiceException.EnderecoId);
                }

                if (!clienteRepository.Exists(request.ClienteId))
                {
                    throw new ServiceException(TypeServiceException.ClienteId);
                }

                var entity = mapper.Map<Endereco>(request);
                entity.Id = id;

                return repository.Update(entity);
            }
            else
            {
                throw new ServiceException(result.Errors.First().ErrorMessage);
            }
        }
    }
}