using FluentValidation;
using System;

namespace ValueObjects.PT_br.Pessoa
{
    public class Nome : ValueObjectBase<Nome>
    {
        public Nome(string primeiroNome, string sobreNome)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;
        }

        public string PrimeiroNome { get; private set; }

        public string SobreNome { get; private set; }

        public string NomeCompleto =>        
            String.Concat(PrimeiroNome, " ", SobreNome); 
        

        protected override void Validar()
        {
            ValidarPrimeiroNome();
            ValidarSobreNome();

            ResultadoValidacao = Validate(this);
        }

        private void ValidarPrimeiroNome()
        {
            RuleFor(e => e.PrimeiroNome)
                .NotEmpty().WithMessage("O primeiro nome não pode ser vazio")
                .NotNull().WithMessage("O primeiro nome não pode ser nulo")
                .MinimumLength(3).WithMessage("O primeiro nome deve ter pelo menos 03 caracteres");
        }

        private void ValidarSobreNome()
        {
            RuleFor(e => e.SobreNome)
                .NotEmpty().WithMessage("O sobrenome não pode ser vazio")
                .NotNull().WithMessage("O sobrenome não pode ser nulo")
                .MinimumLength(2).WithMessage("O sobrenome deve ter pelo menos 02 caracteres");
        }
    }
}
