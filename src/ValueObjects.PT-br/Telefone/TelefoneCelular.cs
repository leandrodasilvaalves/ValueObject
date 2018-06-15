using FluentValidation;

namespace ValueObjects.PT_br.Telefone
{
    public class TelefoneCelular : TelefoneFixo
    {
        public TelefoneCelular(string ddd, string numero) : base(ddd, numero)
        {
        }
        
        protected override void ValidarNumero()
        {
            RuleFor(e => e.Numero)
                .MinimumLength(9).WithMessage("O número do celular deve ter 09 caracteres")
                .MaximumLength(9).WithMessage("O número do celular deve ter 09 caracteres")
                .NotEmpty().WithMessage("O número do celular não pode ser vazio")
                .NotNull().WithMessage("O número do celular não pode ser nulo");
        }
    }
}
