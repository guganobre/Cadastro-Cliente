namespace GestaoCliente.Core.Domain
{
    // Enderecos
    /// <summary>
    /// Tabela para armazenas os logradouros dos clientes
    /// </summary>
    public class Endereco
    {
        /// <summary>
        /// Chave da tabela endereço
        /// </summary>
        public Guid Id { get; set; } // Id (Primary key)

        /// <summary>
        /// Campo com o detalhe/nome da rua do endereço
        /// </summary>
        public string Nome { get; set; } = string.Empty; // Nome (length: 500)

        /// <summary>
        /// Numero do endereço
        /// </summary>
        public string? Numero { get; set; } // Numero (length: 10)

        /// <summary>
        /// Campo descritivo para detalhar o endereço
        /// </summary>
        public string? Complemento { get; set; } // Complemento (length: 255)

        /// <summary>
        /// Apelido identificador via sistema do enderço
        /// </summary>
        public string Apelido { get; set; } = string.Empty; // Apelido (length: 50)

        /// <summary>
        /// Chave da tabela logradouro
        /// </summary>
        public int LogradouroId { get; set; } // LogradouroId

        /// <summary>
        /// Chave da tabela Cliente
        /// </summary>
        public Guid ClienteId { get; set; } // ClienteId

        // Foreign keys

        /// <summary>
        /// Cliente pai apontado por [Enderecos].([ClienteId]) (Fk_Clientes_Enderecos)
        /// </summary>
        public Cliente Cliente { get; set; } // Fk_Clientes_Enderecos

        /// <summary>
        /// Logradouro pai apontado por [Enderecos].([LogradouroId]) (Fk_Logradouros_Enderecos)
        /// </summary>
        public Logradouro Logradouro { get; set; } // Fk_Logradouros_Enderecos

        public Endereco()
        {
            Id = Guid.NewGuid();
        }
    }
}