using FluentValidation;

namespace ValueObjects.PT_br.Web
{
    public class Email : ValueObjectBase<Email>
    {
        public Email(string enderecoEmail) => this.EnderecoEmail = enderecoEmail;        

        public string EnderecoEmail { get; private set; }

        protected override void Validar()
        {
            ValidarEnderecoEmail();
            ResultadoValidacao = Validate(this);
        }

        private void ValidarEnderecoEmail()
        {
            RuleFor(e => e.EnderecoEmail)
                .EmailAddress().WithMessage("O e-mamil informado não é válido");
        }
    }
}
