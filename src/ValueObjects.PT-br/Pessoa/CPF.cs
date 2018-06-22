using FluentValidation;
using System.Text.RegularExpressions;
using ValueObjects.PT_br.Outros;

namespace ValueObjects.PT_br.Pessoa
{
    public class CPF : ValueObjectBase<CPF>
    {
        public CPF(string numero, UF uF)
        {
            Numero = numero;
            UF = uF;
        }

        public CPF(string numero)
        {
            Numero = numero;
        }

        public string Numero { get; private set; }
        public UF UF { get; private set; }

        protected override void Validar()
        {
            ValidarNumeroCPF();

            ResultadoValidacao = Validate(this);
        }

        public void ValidarNumeroCPF()
        {
            RuleFor(e => e.Numero)
                .NotNull().WithMessage("O número do CPF não pode ser nulo")
                .Must(ValidarNumero).WithMessage("O número do CPF é inváldio");
        }

        public static bool ValidarNumero(string numeroCPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempNumeroCPF;
            string digito;
            int soma;
            int resto;
            if (numeroCPF == null)
                return false;

            numeroCPF = numeroCPF.Trim();

            numeroCPF = Regex.Replace(numeroCPF, @"[^\d]", "");
            if (numeroCPF.Length != 11)
                return false;
            tempNumeroCPF = numeroCPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempNumeroCPF[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempNumeroCPF = tempNumeroCPF + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempNumeroCPF[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return numeroCPF.EndsWith(digito);
        }
    }
}
