using FluentValidation;
using GestaoCliente.Core.Domain.DTOs.Requests;
using GestaoCliente.Core.Domain.Exceptions;

namespace GestaoCliente.Core.Application.Validators
{
    internal class ClientDTORequestValidator : AbstractValidator<ClienteDTORequest>
    {
        public ClientDTORequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteNome))
                .NotEmpty()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteNome))
                .MaximumLength(255)
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteNome));

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteEmail))
                .MaximumLength(255)
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteEmail))
                .EmailAddress()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.ClienteEmail));
        }
    }
}