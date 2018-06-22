using ValueObjects.PT_br.Pessoa;
using Xunit;
using System;
using ValueObjects.PT_br.Outros;
using System.Globalization;

namespace ValueObjects.PT_br.Testes.Pessoa
{
    public class RGTestes : TesteBase<RG>
    {
        [Theory]
        [InlineData("456557","")]
        [InlineData("456557ABC", "O número do RG informado é inválido")]
        [InlineData("ABCDEFG", "O número do RG informado é inválido")]
        [InlineData(null, "O número do RG não deve ser nulo")]
        [InlineData("", "O número do RG não deve ser vazio")]
        public void Numero(string numero, string mensagemEsperada)
        {
            // Arrange
            var rg = new RG(numero, "DGPC");

            // Act
            rg.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, rg);
        }

        [Theory]
        [InlineData("13/11/2001","")]
        [InlineData("13/11/2019", "A data de expedição deve ser menor ou igual a data atual")]
        public void DataExpedicao(string dataExpedicao, string mensagemEsperada)
        {
            // Arrange
            var provider = new CultureInfo("pt-BR");
            string format = "dd/MM/yyyy";
            
            var rg = PrepararRG();
            rg.SetDataExpedicao(DateTime.ParseExact(dataExpedicao, format, provider));

            // Act
            rg.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, rg);
        }

        [Theory]
        [InlineData("DG", "")]
        [InlineData("DGPC","")]
        [InlineData("AAABBB", "")]
        [InlineData("", "O órgão expedidor não pode ser vazio")]
        [InlineData(null, "O órgão expedidor não pode ser nulo")]
        [InlineData("DG6PC", "O orgão expedidor não não deve conter números")]
        [InlineData("D", "O orgão expedidor deve ter pelo menos 02 caracteres")]
        [InlineData("DDDDDDD", "O orgão expedidor deve ter no máximo 06 caracteres")]
        public void OrgaoExpedidor(string orgaoExpedidor, string mensagemEsperada)
        {
            // Arrange
            var rg = PrepararRG();
            rg.SetOrgaoExpedidor(orgaoExpedidor);

            // Act
            rg.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, rg);
        }
        
        [Theory]
        [InlineData("DF", "Distrito Federal", "")]
        [InlineData("DFA", "Distrito Federal", "A UF informada é inválida")]
        [InlineData("DF", "DistritoFederal", "A UF informada é inválida")]
        [InlineData("", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A UF informada é inválida")]
        [InlineData(null, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A UF informada é inválida")]
        [InlineData("DF", "", "A UF informada é inválida")]
        [InlineData("DF", null, "A UF informada é inválida")]
        [InlineData("", "", "A UF informada é inválida")]
        [InlineData(null, null, "A UF informada é inválida")]
        public void UF(string ufSigla, string ufNome, string mensagemEsperada)
        {
            // Arrange
            var rg = PrepararRG();
            var uf = new UF(ufSigla, ufNome);
            rg.SetUF(uf);

            // Act
            rg.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, rg);
        }


        #region Metodos Privados

        private RG PrepararRG()
        {
            return new RG("456557", DateTime.Now, "SSP", new UF("GO", "Goiás"));
        }

        #endregion
    }
}
