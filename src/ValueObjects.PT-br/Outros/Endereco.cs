using System;
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

        public Endereco(string logradouro, string complemento, string numero, string bairro, string cep, string cidade, UF uF)
        {
            this.Logradouro = logradouro;
            this.Complemento = complemento;
            this.Numero = numero;
            this.Bairro = bairro;
            this.CEP = cep;
            this.Cidade = cidade;
            this.UF = uF;
        }

        #region Metodos Set

        public void SetLogradouro(string logradouro) => this.Logradouro = logradouro;

        public void SetComplemento(string complemento) => this.Complemento = complemento;

        public void SetBairro(string bairro) => this.Bairro = bairro;

        public void SetCidade(string cidade) => this.Cidade = cidade;

        public void SetUF(UF uf) => this.UF = uf;

        #endregion

        #region Metodos Validacao

        protected override void Validar()
        {
            ValidarLogradouro();
            ValidarComplemento();
            ValidarBairro();
            ValidarCidade();
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

        private void ValidarBairro()
        {
            RuleFor(e => e.Bairro)
                .NotNull().WithMessage("O campo bairro não pode ser nulo")
                .NotEmpty().WithMessage("O campo bairro não pode ser vazio")
                .MinimumLength(2).WithMessage("O campo bairro deve ter pelo menos 02 caracteres")
                .MaximumLength(40).WithMessage("O campo bairro deve ter no máximo 40 caracteres");
        }

        private void ValidarCidade()
        {
            RuleFor(e => e.Cidade)
                .NotNull().WithMessage("A cidade não pode ser nula")
                .NotEmpty().WithMessage("A cidade não pode ser vazia")
                .MinimumLength(2).WithMessage("A cidade deve ter pelo menos 02 caracteres")
                .MaximumLength(40).WithMessage("A cidade deve ter no máximo 40 caracteres");
        }

        private void ValidarUF()
        {
            RuleFor(e => e.UF)
                .Must(e => e.EstaValido()).WithMessage("A UF informada é inválida");
        }
        
        #endregion
    }
}
