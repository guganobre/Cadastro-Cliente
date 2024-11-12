namespace GestaoCliente.Core.Domain.Entities
{
    // TiposLogradouro
    /// <summary>
    /// Tipos de logradouros para cadastro de endereço
    /// </summary>
    public class TiposLogradouro
    {
        /// <summary>
        /// Chave da tabela tipo logradouro
        /// </summary>
        public int Id { get; set; } // Id (Primary key)

        /// <summary>
        /// Nome identificador do tipo logradouro
        /// </summary>
        public string? Nome { get; set; } // Nome (Tamanho máximo: 50)

        /// <summary>
        /// Status do tipo logradouro
        /// </summary>
        public bool Ativo { get; set; } // Ativo

        // Reverse navigation

        /// <summary>
        /// Enderecos filhos, onde [Enderecos].[LogradouroId] aponta para esta entidade (Fk_TiposLogradouro_Enderecos)
        /// </summary>
        public ICollection<Endereco> Enderecos { get; set; } // Enderecos.Fk_TiposLogradouro_Enderecos

        public TiposLogradouro()
        {
            Ativo = true;
            Enderecos = new HashSet<Endereco>();
        }
    }
}