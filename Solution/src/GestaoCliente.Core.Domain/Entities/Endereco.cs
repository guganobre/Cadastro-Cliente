namespace GestaoCliente.Core.Domain.Entities
{
    // Enderecos
    /// <summary>
    /// Tabela para armazenar os logradouros dos clientes
    /// </summary>
    public class Endereco
    {
        /// <summary>
        /// Chave da tabela endereço
        /// </summary>
        public Guid Id { get; set; } // Id (Primary key)

        /// <summary>
        /// Campo com o detalhe/nome do logradouro
        /// </summary>
        public string Logradouro { get; set; } = string.Empty; // Logradouro (Tamanho máximo: 500)

        /// <summary>
        /// Numero do endereço
        /// </summary>
        public string? Numero { get; set; } // Numero (Tamanho máximo: 10)

        /// <summary>
        /// Campo descritivo para detalhar o endereço
        /// </summary>
        public string? Complemento { get; set; } // Complemento (Tamanho máximo: 255)

        /// <summary>
        /// Apelido identificador via sistema do enderço
        /// </summary>
        public string Apelido { get; set; } = string.Empty; // Apelido (Tamanho máximo: 50)

        /// <summary>
        /// Chave da tabela tipo logradouro
        /// </summary>
        public int LogradouroId { get; set; } // LogradouroId

        /// <summary>
        /// Chave da tabela Cliente
        /// </summary>
        public Guid ClienteId { get; set; } // ClienteId

        // Foreign keys

        /// <summary>
        /// Cliente pai apontador por [Enderecos].([ClienteId]) (Fk_Clientes_Enderecos)
        /// </summary>
        public Cliente Cliente { get; set; } // Fk_Clientes_Enderecos

        /// <summary>
        /// TiposLogradouro pai apontador por [Enderecos].([LogradouroId]) (Fk_TiposLogradouro_Enderecos)
        /// </summary>
        public TiposLogradouro TiposLogradouro { get; set; } // Fk_TiposLogradouro_Enderecos

        public Endereco()
        {
            Id = Guid.NewGuid();
        }
    }
}