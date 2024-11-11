﻿using AutoMapper;
using FluentValidation;
using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Application.DTOs.Validators;
using GestaoCliente.Core.Domain.Entities;
using GestaoCliente.Core.Domain.Exceptions;
using GestaoCliente.Core.Domain.Interface.DTOs.Requests;
using GestaoCliente.Core.Domain.Interface.Repositories;
using GestaoCliente.Core.Domain.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository repository;
        private readonly IMapper mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool Delete(Guid id)
        {
            var exists = repository.Get(w => w.Id == id).Any();
            if (!exists)
            {
                throw new ServiceException(TypeServiceException.ClienteId);
            }

            return repository.Delete(id);
        }

        public List<Cliente> GetAll() => repository.Get().OrderBy(o => o.Nome).ToList();

        public Cliente? GetById(Guid? id) => repository.Get(w => w.Id == id).FirstOrDefault();

        public Guid? Insert(IClienteRequest model)
        {
            var validator = new ClientRequestValidator();

            var result = validator.Validate(model);
            if (result.IsValid)
            {
                return repository.Add(mapper.Map<Cliente>(model));
            }
            else
            {
                throw new ServiceException(result.Errors.First().ErrorMessage);
            }
        }

        public bool Update(Guid id, IClienteRequest model)
        {
            var exists = repository.Get(w => w.Id == id).Any();
            if (!exists)
            {
                throw new ServiceException(TypeServiceException.ClienteId);
            }

            var validator = new ClientRequestValidator();
            var result = validator.Validate(model);
            if (result.IsValid)
            {
                var entity = mapper.Map<Cliente>(model);
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