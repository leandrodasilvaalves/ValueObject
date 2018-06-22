using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace ValueObjects.PT_br.Empresa
{
    public class CNPJ : ValueObjectBase<CNPJ>
    {
        public CNPJ(string numero)
        {
            Numero = numero;
        }

        public CNPJ(string numero, DateTime dataAbertura)
        {
            Numero = numero;
            DataAbertura = dataAbertura;
        }

        public string Numero { get; private set; }
        public DateTime DataAbertura { get; private set; }
        
        protected override void Validar()
        {
            ValidarNumeroCNPJ();
            ValidarDataAbertura();
            this.ResultadoValidacao = Validate(this);
        }

        private void ValidarNumeroCNPJ()
        {
            RuleFor(e => e.Numero)                
                .NotNull().WithMessage("O CNPJ não pode ser nulo")
                .Must(ValidarNumero).WithMessage("O CNPJ informado é inválido");
        }

        public static bool ValidarNumero(string numeroCNPJ)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            if (numeroCNPJ == null) return false;

            numeroCNPJ = numeroCNPJ.Trim();
            numeroCNPJ = Regex.Replace(numeroCNPJ, @"[^\d]", "");

            if (numeroCNPJ.Length != 14)
                return false;

            tempCnpj = numeroCNPJ.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return numeroCNPJ.EndsWith(digito);
        }

        private void ValidarDataAbertura()
        {
            RuleFor(e => e.DataAbertura)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de abertura deve ser menor ou igual a data atual")
                .When(e => e.DataAbertura != null);
        }
    }
}
