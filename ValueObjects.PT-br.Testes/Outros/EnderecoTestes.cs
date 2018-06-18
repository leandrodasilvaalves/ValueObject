using ValueObjects.PT_br.Outros;
using Xunit;

namespace ValueObjects.PT_br.Testes.Outros
{
    public class EnderecoTestes : TesteBase<Endereco>
    {
        [Theory]
        [InlineData("Rua ABCDEFG", "")]
        [InlineData("Av. A", "")]
        [InlineData("Av", "O logradouro deve ter pelo menos 03 caracteres")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "O logradouro deve ter no máximo 40 caracteres")]
        public void Logradouro(string logradouro, string mensagemEsperada)
        {
            // Arrange
            var endereco = PrepararEndereco();
            endereco.SetLogradouro(logradouro);

            // Act
            endereco.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, endereco);
        }


        [Theory]
        [InlineData("QD 205 Lt 27", "")]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData("Qd 2", "")]
        [InlineData("QD", "O complemento quando informado deve ter pelo menos 03 caracteres")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "O complemento quando informado deve ter no máximo 40 caracteres")]
        public void Complemento(string complemento, string mensagemEsperada)
        {
            // Arrange
            var endereco = PrepararEndereco();
            endereco.SetComplemento(complemento);

            // Act
            endereco.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, endereco);
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
            var endereco = PrepararEndereco();
            var uf = new UF(ufSigla, ufNome);
            endereco.SetUF(uf);

            // Act
            endereco.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, endereco);
        }



        #region Metodos Privados

        private Endereco PrepararEndereco()
        {
            var uf = new UF("GO", "Goiás");
            return new Endereco("Rua Maria Helena Cardoso", 
                                "QD 205 Lt 27", 
                                "500", 
                                "Parq Estrela Dalva 3", 
                                "72831060", 
                                "Luziânia",
                                uf);
        }

        #endregion
    }
}
