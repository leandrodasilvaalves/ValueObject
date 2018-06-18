using FluentValidation;

namespace ValueObjects.PT_br.Outros
{
    public class Endereco : ValueObjectBase<Endereco>
    {
        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public UF UF { get; private set; }

        public Endereco(string logradouro, string complemento, string numero, string bairro, string cEP, string cidade, UF uF)
        {
            this.Logradouro = logradouro;
            this.Complemento = complemento;
            this.Numero = numero;
            this.Bairro = bairro;
            this.CEP = cEP;
            this.Cidade = cidade;
            this.UF = uF;
        }

        public void SetLogradouro(string logradouro) => this.Logradouro = logradouro;

        public void SetComplemento(string complemento) => this.Complemento = complemento;

        public void SetUF(UF uf) => this.UF = uf;

        protected override void Validar()
        {
            ValidarLogradouro();
            ValidarComplemento();
            ValidarUF();
            ResultadoValidacao = Validate(this);
        }

        private void ValidarLogradouro()
        {
            RuleFor(e => e.Logradouro)                
                .MinimumLength(3).WithMessage("O logradouro deve ter pelo menos 03 caracteres")
                .MaximumLength(40).WithMessage("O logradouro deve ter no máximo 40 caracteres")
                .NotEmpty().WithMessage("O logradouro não pode ser vazio")
                .NotNull().WithMessage("O logradouro não pode ser nulo");
        }

        private void ValidarComplemento()
        {
            RuleFor(e => e.Complemento)
                .MinimumLength(3).WithMessage("O complemento quando informado deve ter pelo menos 03 caracteres")
                .MaximumLength(40).WithMessage("O complemento quando informado deve ter no máximo 40 caracteres")
                .When(e => !string.IsNullOrEmpty(e.Complemento));
        }

        private void ValidarUF()
        {
            RuleFor(e => e.UF)
                .Must(e => e.EstaValido()).WithMessage("A UF informada é inválida");
        }
    }
}
