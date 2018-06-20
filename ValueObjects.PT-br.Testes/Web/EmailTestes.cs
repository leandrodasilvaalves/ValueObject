using ValueObjects.PT_br.Web;
using Xunit;

namespace ValueObjects.PT_br.Testes.Web
{
    public class EmailTestes : TesteBase<Email>
    {
        [Theory]
        [InlineData("leandro.silva.alves86@gmail.com","")]
        [InlineData("leandro.alves@s2it.com.br", "")]
        [InlineData("leandro.silva.alves86gmail.com", "O e-mamil informado não é válido")]
        [InlineData("leandro.silva.alves86@gmailcom", "O e-mamil informado não é válido")]
        [InlineData("leandro.silva.alves86mailcom", "O e-mamil informado não é válido")]
        [InlineData("leandro.silva.alves86gmail.com.com.com.com.com", "O e-mamil informado não é válido")]
        [InlineData("@@@@@leandro.silva.alves86gmail.com", "O e-mamil informado não é válido")]
        public void EnderecoEmail(string enderecoEmail, string mensagemEsperada)
        {
            // Arrange
            var email = new Email(enderecoEmail);

            // Act
            email.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, email);
        }
    }
}
