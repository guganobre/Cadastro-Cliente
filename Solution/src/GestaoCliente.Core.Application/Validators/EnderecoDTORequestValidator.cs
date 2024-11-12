using FluentValidation;
using GestaoCliente.Core.Application.DTOs.Requests;
using GestaoCliente.Core.Domain.DTOs.Requests;
using GestaoCliente.Core.Domain.Exceptions;

namespace GestaoCliente.Core.Application.Validators
{
    internal class EnderecoDTORequestValidator : AbstractValidator<EnderecoDTORequest>
    {
        public EnderecoDTORequestValidator()
        {
            RuleFor(x => x.Logradouro)
                .NotNull()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.EnderecoLogradouro))
                .NotEmpty()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.EnderecoLogradouro))
                .MaximumLength(500)
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.EnderecoLogradouro));

            RuleFor(x => x.Numero)
                .MaximumLength(10)
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.EnderecoNumero));

            RuleFor(x => x.Complemento)
                .MaximumLength(255)
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.EnderecoComplemento));

            RuleFor(x => x.Apelido)
                .NotNull()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.EnderecoApelido))
                .NotEmpty()
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.EnderecoApelido))
                .MaximumLength(50)
                .WithMessage(ServiceException.GetMensagemErro(TypeServiceException.EnderecoApelido));
        }
    }
}