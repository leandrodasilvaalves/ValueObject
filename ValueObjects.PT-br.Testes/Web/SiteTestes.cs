using ValueObjects.PT_br.Web;
using Xunit;

namespace ValueObjects.PT_br.Testes.Web
{
    public class SiteTestes : TesteBase<Site>
    {
        [Theory]   
        [InlineData("https://www.google.com.br","")]
        [InlineData("http://www.google.com.br", "")]
        [InlineData("https://www.google.com", "")]
        [InlineData("wwwgooglecombr", "O site informado é inválido")]
        [InlineData("https://.com.br", "O site informado é inválido")]
        [InlineData(".com.br", "O site informado é inválido")]
        public void EnderecoSite(string enderecoSite, string mensagemExperada)
        {
            // Arrage
            var site = new Site(enderecoSite);

            // Act
            site.EstaValido();

            // Assert
            AssertMensagemExperada(mensagemExperada, site);
        }
    }
}
