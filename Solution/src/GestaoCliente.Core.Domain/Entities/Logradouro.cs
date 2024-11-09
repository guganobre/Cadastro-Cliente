using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GestaoCliente.Core.Domain
{
    // Logradouros
    /// <summary>
    /// Tipos de logradouros para cadastro de endereço
    /// </summary>
    public class Logradouro
    {
        /// <summary>
        /// Chave da tabela logradouro
        /// </summary>
        public int Id { get; set; } // Id (Primary key)

        /// <summary>
        /// Nome identificador do logradouro
        /// </summary>
        public string Nome { get; set; } = string.Empty; // Nome (length: 50)

        /// <summary>
        /// Status do logradouro
        /// </summary>
        public bool Ativo { get; set; } // Ativo

        /// <summary>
        /// Enderecos filhos, onde [Enderecos].[LogradouroId] aponta para esta entidade (Fk_Logradouros_Enderecos)
        /// </summary>
        public ICollection<Endereco> Enderecos { get; set; } // Enderecos.Fk_Logradouros_Enderecos

        public Logradouro()
        {
            Ativo = true;
            Enderecos = new HashSet<Endereco>();
        }
    }
}