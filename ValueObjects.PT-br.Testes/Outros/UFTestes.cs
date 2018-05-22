using ValueObjects.PT_br.Outros;
using Xunit;

namespace ValueObjects.PT_br.Testes.Outros
{
    public class UFTestes : TesteBase<UF>
    {
        [Theory]
        [InlineData("GO", "")]
        [InlineData("DF", "")]
        [InlineData("SP", "")]
        [InlineData("MT", "")]
        [InlineData("AJ", "A UF informada é inválida")]
        [InlineData("ST", "A UF informada é inválida")]
        [InlineData("T", "A UF deve ter 02 caracteres")]
        [InlineData("MTB", "A UF deve ter 02 caracteres")]
        [InlineData("", "A UF não pode ser vazia")]
        [InlineData(null, "A UF não pode ser nula")]
        public void UF(string uf, string mensagemEsperada)
        {
            // Arrange
            var _uf = new UF(uf,"Goiás");

            //  Act
            _uf.EstaValido();

            //  Assert
            AssertMensagemExperada(mensagemEsperada, _uf);
        }

        [Theory]
        [InlineData("Goiás","")]
        [InlineData("Distrito Federal", "")]
        [InlineData("São Paulo", "")]
        [InlineData("Goiásss", "O nome da UF informado é inválido")]
        [InlineData("abcdef", "O nome da UF informado é inválido")]
        [InlineData("", "O nome da UF não pode ser vazio")]
        [InlineData(null, "O nome da UF não pode ser nulo")]
        public void NomeUF(string nomeUf, string mensagemEsperada)
        {
            // Arrange
            var _uf = new UF("GO", nomeUf);

            //  Act
            _uf.EstaValido();

            //  Assert
            AssertMensagemExperada(mensagemEsperada, _uf);
        }
    }
}
