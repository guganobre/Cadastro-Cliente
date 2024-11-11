using GestaoCliente.Core.Domain.Interface.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Application.DTOs.Requests
{
    /// <summary>
    /// Interface para requisição de um novo cliente
    /// </summary>
    public class ClienteRequest : IClienteRequest
    {
        /// <summary>
        /// Nome do cliente (Tamanho máximo: 255)
        /// </summary>
        public string? Nome { get; set; }

        /// <summary>
        /// E-mail do cliente, campo único para cada cliente (Tamanho máximo: 255)
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
