using ValueObjects.PT_br.Telefone;
using Xunit;

namespace ValueObjects.PT_br.Testes.Telefone
{
    public class TelefoneCelularTestes : TesteBase<TelefoneFixo>
    {
        [Theory]
        [InlineData("993947762", "")]
        [InlineData("991077157", "")]
        [InlineData("91077157", "O número do celular deve ter 09 caracteres")]
        [InlineData("991077", "O número do celular deve ter 09 caracteres")]
        [InlineData("991", "O número do celular deve ter 09 caracteres")]
        [InlineData("9", "O número do celular deve ter 09 caracteres")]
        [InlineData("", "O número do celular não pode ser vazio")]
        [InlineData(null, "O número do celular não pode ser nulo")]
        public void Numero(string numero, string mensagemEsperada)
        {
            // Arrange
            var telefoneCelular = new TelefoneCelular("61", numero);

            // Act
            telefoneCelular.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, telefoneCelular);
        }
    }
}
