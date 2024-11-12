using System.ComponentModel.DataAnnotations;

namespace GestaoCliente.Presentation.Web.Models
{
    public struct ClienteViewModel
    {
        public ClienteViewModel()
        {
        }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
        public string Email { get; set; } = string.Empty;
    }
}