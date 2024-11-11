using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Domain.Interface.DTOs.Requests
{
    /// <summary>
    /// Interface para requisição de um novo cliente
    /// </summary>
    public interface IClienteRequest
    {
        /// <summary>
        /// Nome do cliente (Tamanho máximo: 255)
        /// </summary>
        string? Nome { get; set; }

        /// <summary>
        /// E-mail do cliente, campo único para cada cliente (Tamanho máximo: 255)
        /// </summary>
        string Email { get; set; }
    }
}
