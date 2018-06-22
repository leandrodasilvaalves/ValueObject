using System;
using System.Globalization;
using ValueObjects.PT_br.Empresa;
using Xunit;

namespace ValueObjects.PT_br.Testes.Empresa
{
    public class CNPJTestes : TesteBase<CNPJ>
    {
        [Theory]
        [InlineData("16758753000109", "")]
        [InlineData("16.758.753/0001-09", "")]
        [InlineData("11222333000144", "O CNPJ informado é inválido")]
        [InlineData("11.222.333/0001-44", "O CNPJ informado é inválido")]
        [InlineData("", "O CNPJ informado é inválido")]
        [InlineData(null, "O CNPJ não pode ser nulo")]
        public void Numero(string numeroCNPJ, string mensagemEsperada)
        {
            // Arrange
            var cnpj = new CNPJ(numeroCNPJ);

            // Act
            cnpj.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, cnpj);
        }

        [Theory]
        [InlineData("13/11/2001", "")]
        [InlineData("13/11/2019", "A data de abertura deve ser menor ou igual a data atual")]
        public void DataAbertura(string dataAbertura, string mensagemEsperada)
        {
            // Arrange
            var provider = new CultureInfo("pt-BR");
            string format = "dd/MM/yyyy";

            var cnpj = new CNPJ("16758753000109", DateTime.ParseExact(dataAbertura, format, provider));

            // Act
            cnpj.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, cnpj);
        }
    }
}
