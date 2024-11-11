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
            { TypeServiceException.ClienteNome, "O campo nome não foi preenchido corretamente." },
            { TypeServiceException.ClienteTamanhoNome, "O campo nome ultrapassou o limite de caracteres." },
            { TypeServiceException.ClienteEmail, "O campo e-mail não foi preenchido corretamente." },
            { TypeServiceException.ClienteTamanhoEmail, "O campo e-mail ultrapassou o limite de caracteres." },
            { TypeServiceException.ClienteId, "O campo Id não foi informado corretamente." },
        };
    }

    public enum TypeServiceException
    {
        ClienteId,
        ClienteEmail,
        ClienteTamanhoEmail,
        ClienteNome,
        ClienteTamanhoNome
    }
}