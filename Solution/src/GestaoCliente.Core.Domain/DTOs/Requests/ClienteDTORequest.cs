namespace GestaoCliente.Core.Domain.DTOs.Requests
{
    /// <summary>
    /// DTO para persitencia de um cliente
    /// </summary>
    public record ClienteDTORequest
    {
        public ClienteDTORequest()
        {
        }

        /// <summary>
        /// Nome do cliente (Tamanho máximo: 255)
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// E-mail do cliente, campo único para cada cliente (Tamanho máximo: 255)
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}