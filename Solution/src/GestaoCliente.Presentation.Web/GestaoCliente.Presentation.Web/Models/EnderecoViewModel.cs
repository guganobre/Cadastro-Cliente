using System.ComponentModel.DataAnnotations;

namespace GestaoCliente.Presentation.Web.Models
{
    public class EnderecoViewModel
    {
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

        //[Required(ErrorMessage = "O nome é obrigatório.")]
        //[StringLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres.")]
        //public string Nome { get; set; } = string.Empty;

        //[Required(ErrorMessage = "O e-mail é obrigatório.")]
        //[EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
        //public string Email { get; set; } = string.Empty;
    }
}