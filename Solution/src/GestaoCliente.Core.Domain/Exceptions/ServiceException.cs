using GestaoCliente.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Domain.Exceptions
{
    public class ServiceException : Exception
    {
        public ServiceException(string? mensagem) : base(mensagem)
        {
        }

        public ServiceException(TypeServiceException type)
            : base(GetMensagemErro(type))
        {
        }

        public static string? GetMensagemErro(TypeServiceException type)
        {
            return _erros.GetValueOrDefault(type);
        }

        private static Dictionary<TypeServiceException, string> _erros = new Dictionary<TypeServiceException, string> {
            { TypeServiceException.ClienteEmail, "O campo e-mail não foi preenchido corretamente." },
            { TypeServiceException.ClienteId, "O campo Id não foi informado corretamente." },
            { TypeServiceException.ClienteNome, "O campo nome não foi preenchido corretamente." },

            { TypeServiceException.EnderecoApelido, "O campo logradouro não foi informado corretamente." },
            { TypeServiceException.EnderecoComplemento, "O campo complemento não foi informado corretamente." },
            { TypeServiceException.EnderecoLogradouro, "O campo logradouro não foi informado corretamente." },
            { TypeServiceException.EnderecoNumero, "O campo numero não foi informado corretamente." },
            { TypeServiceException.EnderecoTipoLogradouro, "O campo tipo logradouro não foi informado corretamente." },

            { TypeServiceException.EnderecoId, "O campo id do endereço não foi informado corretamente." },
        };
    }

    public enum TypeServiceException
    {
        ClienteId,
        ClienteEmail,
        ClienteNome,

        EnderecoApelido,
        EnderecoComplemento,
        EnderecoLogradouro,
        EnderecoNumero,
        EnderecoTipoLogradouro,

        EnderecoId,
    }
}