using ValueObjects.PT_br.Pessoa;
using Xunit;

namespace ValueObjects.PT_br.Testes.Pessoa
{
    public class CPFTestes : TesteBase<CPF>
    {
        [Theory]
        [InlineData("29284157854", "")]
        [InlineData("121.327.860-03", "")]
        [InlineData("558.616.243-13", "")]
        [InlineData("716.540.794-48", "")]
        [InlineData("11122233344", "O número do CPF é inváldio")]
        [InlineData("000000", "O número do CPF é inváldio")]
        [InlineData("1234", "O número do CPF é inváldio")]
        [InlineData("", "O número do CPF é inváldio")]
        [InlineData("12365478990", "O número do CPF é inváldio")]
        [InlineData(null, "O número do CPF não pode ser nulo")]
        public void CPF(string numeroCPF, string mensagemEsperada)
        {
            // Arrange
            var cpf = new CPF(numeroCPF);

            //  Act
            cpf.EstaValido();

            //  Assert
            AssertMensagemExperada(mensagemEsperada, cpf);
        }
    }
}
