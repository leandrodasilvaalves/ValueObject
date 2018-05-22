using FluentValidation;
using FluentValidation.Results;

namespace ValueObjects.PT_br
{
    public abstract class ValueObjectBase<T> : AbstractValidator<T> where T : ValueObjectBase<T>
    {
        public ValueObjectBase()
        {
            ResultadoValidacao = new ValidationResult();
        }

        public ValidationResult ResultadoValidacao { get; set; }

        protected abstract void Validar();

        public bool EstaValido()
        {
            Validar();
            return ResultadoValidacao.IsValid;
        }
    }
}
