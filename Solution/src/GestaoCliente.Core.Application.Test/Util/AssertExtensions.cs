using GestaoCliente.Core.Domain.Exceptions;

namespace GestaoCliente.Core.Application.Test
{
    internal static class AssertExtensions
    {
        public static void ValidarMensagem(this ServiceException ex, TypeServiceException type)
        {
            var mensagem = ServiceException.GetMensagemErro(type);
            if (ex.Message.Equals(mensagem))
            {
                Assert.True(true);
            }
            else
            {
                Assert.Fail($"A mensagem esperada é {mensagem}");
            }
        }

        public static async void ValidarMensagemAsync(this Task<ServiceException> ex, TypeServiceException type)
        {
            var mensagem = ServiceException.GetMensagemErro(type);
            if ((await ex).Message.Equals(mensagem))
            {
                Assert.True(true);
            }
            else
            {
                Assert.Fail($"A mensagem esperada é {mensagem}");
            }
        }
    }
}