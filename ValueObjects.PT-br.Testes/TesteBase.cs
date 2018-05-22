using Xunit;

namespace ValueObjects.PT_br.Testes
{
    public class TesteBase<T> where T : ValueObjectBase<T>
    {
        protected static void AssertMensagemExperada(string mensagemExperada, T entidade)
        {
            Assert.Equal(entidade.ResultadoValidacao.IsValid, string.IsNullOrEmpty(mensagemExperada));

            if (string.IsNullOrEmpty(mensagemExperada))
                Assert.Empty(entidade.ResultadoValidacao.Errors);
            else
                Assert.Contains(entidade.ResultadoValidacao.Errors, e => e.ErrorMessage == mensagemExperada);
        }
    }
}
