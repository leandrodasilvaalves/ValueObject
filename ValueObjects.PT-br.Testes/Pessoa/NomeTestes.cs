using ValueObjects.PT_br.Pessoa;
using Xunit;

namespace ValueObjects.PT_br.Testes.Pessoa
{
    public class NomeTestes : TesteBase<Nome>
    {
        [Theory]
        [InlineData("Leandro", "")]
        [InlineData("Ana", "")]
        [InlineData("An", "O primeiro nome deve ter pelo menos 03 caracteres")]
        [InlineData("", "O primeiro nome não pode ser vazio")]
        [InlineData(null, "O primeiro nome não pode ser nulo")]
        public void PrimeiroNome(string primeiroNome, string mensagemEsperada)
        {
            // Arrange
            var nome = new Nome(primeiroNome, "Batista");

            // Act
            nome.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, nome);
        }

        [Theory]
        [InlineData("Alves", "")]
        [InlineData("Sá", "")]
        [InlineData("A", "O sobrenome deve ter pelo menos 02 caracteres")]
        [InlineData("", "O sobrenome não pode ser vazio")]
        [InlineData(null, "O sobrenome não pode ser nulo")]
        public void SobreNome(string sobreNome, string mensagemEsperada)
        {
            // Arrange
            var nome = new Nome("Leandro", sobreNome);

            // Act
            nome.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, nome);
        }
    }
}
