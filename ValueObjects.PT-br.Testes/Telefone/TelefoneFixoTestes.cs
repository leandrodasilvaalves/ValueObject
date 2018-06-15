using ValueObjects.PT_br.Telefone;
using Xunit;

namespace ValueObjects.PT_br.Testes.Telefone
{
    public class TelefoneFixoTestes : TesteBase<TelefoneFixo>
    {
        [Theory]
        [InlineData("61", "")]
        [InlineData("16", "")]
        [InlineData("614", "O DDD deve ter 02 caracteres")]
        [InlineData("6", "O DDD deve ter 02 caracteres")]
        [InlineData("", "O DDD não pode ser vazio")]
        [InlineData(null, "O DDD não pode ser nulo")]
        public void DDD(string ddd, string mensagemEsperada)
        {
            // Arrange
            var telefoneFixo = new TelefoneFixo(ddd, "33334444");

            // Act
            var msg = telefoneFixo.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, telefoneFixo);
        }

        [Theory]
        [InlineData("36206678","")]
        [InlineData("36415497", "")]
        [InlineData("3620667", "O número do telefone deve ter 08 caracteres")]
        [InlineData("3620", "O número do telefone deve ter 08 caracteres")]
        [InlineData("36", "O número do telefone deve ter 08 caracteres")]
        [InlineData("3", "O número do telefone deve ter 08 caracteres")]
        [InlineData("", "O número do telefone não pode ser vazio")]
        [InlineData(null, "O número do telefone não pode ser nulo")]
        public void Numero(string numero, string mensagemEsperada)
        {
            // Arrange
            var telefoneFixo = new TelefoneFixo("61", numero);

            // Act
            var msg = telefoneFixo.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, telefoneFixo);
        }
    }
}
