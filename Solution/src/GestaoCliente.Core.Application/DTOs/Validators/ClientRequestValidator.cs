using FluentValidation;
using GestaoCliente.Core.Domain.Exceptions;
using GestaoCliente.Core.Domain.Interface.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Application.DTOs.Validators
{
    internal class ClientRequestValidator : AbstractValidator<IClienteRequest>
    {
        public ClientRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteNome))
                .NotEmpty()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteNome))
                .MaximumLength(255)
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteTamanhoNome));

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteEmail))
                .MaximumLength(255)
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteTamanhoEmail))
                .EmailAddress()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteEmail));
        }
    }
}