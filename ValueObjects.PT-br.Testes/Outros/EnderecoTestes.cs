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
        [InlineData("","")]
        [InlineData(null, "")]
        [InlineData("1", "")]
        [InlineData("12345", "")]
        [InlineData("123456", "O número quando informado deve ter no máximo 5 caracteres")]
        [InlineData("123456789", "O número quando informado deve ter no máximo 5 caracteres")]
        public void Numero(string numero, string mensagemEsperada)
        {
            // Arrange
            var endereco = PrepararEndereco();
            endereco.SetNumero(numero);

            // Act
            endereco.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, endereco);
        }

        [Theory]
        [InlineData("PED3","")]
        [InlineData("PE", "")]
        [InlineData("P", "O bairro deve ter pelo menos 02 caracteres")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "O bairro deve ter no máximo 40 caracteres")]
        [InlineData("", "O bairro não pode ser vazio")]
        [InlineData(null, "O bairro não pode ser nulo")]
        public void Bairro(string bairro, string mensagemEsperada)
        {
            // Arrange
            var endereco = PrepararEndereco();
            endereco.SetBairro(bairro);

            // Act
            endereco.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemEsperada, endereco);
        }

        [Theory]
        [InlineData("Luziânia", "")]
        [InlineData("Lu", "")]
        [InlineData("L", "A cidade deve ter pelo menos 02 caracteres")]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "A cidade deve ter no máximo 40 caracteres")]
        [InlineData("", "A cidade não pode ser vazia")]
        [InlineData(null, "A cidade não pode ser nula")]
        public void Cidade(string cidade, string mensagemEsperada)
        {
            // Arrange
            var endereco = PrepararEndereco();
            endereco.SetCidade(cidade);

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
