namespace GestaoCliente.Core.Domain.Entities
{
    // Clientes
    /// <summary>
    /// Armazenamento dos cliente
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Identificador único do cliente
        /// </summary>
        public Guid Id { get; set; } // Id (Primary key)

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string? Nome { get; set; } // Nome (Tamanho máximo: 255)

        /// <summary>
        /// E-mail do cliente, campo único para cada cliente
        /// </summary>
        public string Email { get; set; } = string.Empty; // Email (Tamanho máximo: 255)

        // Reverse navigation

        /// <summary>
        /// Enderecos filhos, onde [Enderecos].[ClienteId] aponta para esta entidade (Fk_Clientes_Enderecos)
        /// </summary>
        public ICollection<Endereco> Enderecos { get; set; } // Enderecos.Fk_Clientes_Enderecos

        public Cliente()
        {
            Id = Guid.NewGuid();
            Enderecos = new HashSet<Endereco>();
        }
    }
}