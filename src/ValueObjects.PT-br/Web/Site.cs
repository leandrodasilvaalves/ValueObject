using System;
using FluentValidation;

namespace ValueObjects.PT_br.Web
{
    public class Site : ValueObjectBase<Site>
    {
        public string EnderecoSite { get; private set; }

        public Site(string enderecoSite) => this.EnderecoSite = enderecoSite;

        protected override void Validar()
        {
            ValidarEnderecoSite();
            ResultadoValidacao = Validate(this);
        }

        private void ValidarEnderecoSite()
        {
            RuleFor(e => e.EnderecoSite)
                .Must(ValidarSite).WithMessage("O site informado é inválido");
        }

        private bool ValidarSite(string enderecoSite) =>
            Uri.IsWellFormedUriString(enderecoSite, UriKind.Absolute);
        
    }
}
