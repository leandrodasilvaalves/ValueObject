using FluentValidation;

namespace ValueObjects.PT_br.Telefone
{
    public class TelefoneFixo: ValueObjectBase<TelefoneFixo>
    {
        public TelefoneFixo(string ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;
        }

        public string DDD { get; private set; }
        public string Numero { get; private set; }

        protected override void Validar()
        {
            ValidarDDD();
            ValidarNumero();

            ResultadoValidacao = Validate(this);
        }

        private void ValidarDDD()
        {
            RuleFor(e => e.DDD)
                .MinimumLength(2).WithMessage("O DDD deve ter 02 caracteres")
                .MaximumLength(2).WithMessage("O DDD deve ter 02 caracteres")
                .NotNull().WithMessage("O DDD não pode ser nulo")
                .NotEmpty().WithMessage("O DDD não pode ser vazio");

        }

        private void ValidarNumero()
        {
            RuleFor(e => e.Numero)
                .MinimumLength(8).WithMessage("O número do telefone deve ter 08 caracteres")
                .MaximumLength(8).WithMessage("O número do telefone deve ter 08 caracteres")
                .NotEmpty().WithMessage("O número do telefone não pode ser vazio")
                .NotNull().WithMessage("O número do telefone não pode ser nulo");
        }
    }
}
