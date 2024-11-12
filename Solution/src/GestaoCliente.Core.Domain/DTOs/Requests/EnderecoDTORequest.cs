namespace GestaoCliente.Core.Application.DTOs.Requests
{
    /// <summary>
    /// DTO para criação do endereço
    /// </summary>
    public struct EnderecoDTORequest
    {
        public EnderecoDTORequest()
        {
        }

        /// <summary>
        /// Campo com o detalhe/nome do logradouro
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Numero do endereço
        /// </summary>
        public string? Numero { get; set; }

        /// <summary>
        /// Campo descritivo para detalhar o endereço
        /// </summary>
        public string? Complemento { get; set; }

        /// <summary>
        /// Apelido identificador via sistema do enderço
        /// </summary>
        public string Apelido { get; set; }

        /// <summary>
        /// Chave da tabela tipo logradouro
        /// </summary>
        public int LogradouroId { get; set; }

        /// <summary>
        /// Chave da tabela Cliente
        /// </summary>
        public Guid ClienteId { get; set; }
    }
}