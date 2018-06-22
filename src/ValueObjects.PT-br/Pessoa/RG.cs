using FluentValidation;
using System;
using ValueObjects.PT_br.Outros;

namespace ValueObjects.PT_br.Pessoa
{
    public class RG : ValueObjectBase<RG>
    {
        public string Numero { get; private set; }
        public DateTime DataExpedicao { get; private set; }
        public string OrgaoExpedidor { get; private set; }
        public UF UF { get; private set; }

        public RG(string numero, string orgaoExpedidor) {
            this.Numero = numero;
            this.OrgaoExpedidor = orgaoExpedidor;
        }

        public RG(string numero, DateTime dataExpedicao, string orgaoExpedidor, UF uF)
        {
            Numero = numero;
            DataExpedicao = dataExpedicao;
            OrgaoExpedidor = orgaoExpedidor;
            UF = uF;
        }

        public void SetDataExpedicao(DateTime dataExpedicao) => this.DataExpedicao = dataExpedicao;

        public void SetOrgaoExpedidor(string orgaoExpedidor) => this.OrgaoExpedidor = orgaoExpedidor;

        public void SetUF(UF uf) => this.UF = uf;


        protected override void Validar()
        {
            ValidarNumero();
            ValidarDataExpedicao();
            ValidarOrgaoExpedidor();
            ValidarUF();
            ResultadoValidacao = Validate(this);
        }

        private void ValidarOrgaoExpedidor()
        {
            RuleFor(e => e.OrgaoExpedidor)
                .NotEmpty().WithMessage("O órgão expedidor não pode ser vazio")
                .NotNull().WithMessage("O órgão expedidor não pode ser nulo")                
                .Matches(@"^[a-zA-Z]+$").WithMessage("O orgão expedidor não não deve conter números")
                .MinimumLength(2).WithMessage("O orgão expedidor deve ter pelo menos 02 caracteres")
                .MaximumLength(6).WithMessage("O orgão expedidor deve ter no máximo 06 caracteres");
        }

        private void ValidarDataExpedicao()
        {
            RuleFor(e => e.DataExpedicao)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de expedição deve ser menor ou igual a data atual")                
                .When(e => e.DataExpedicao != null);
        }

        private void ValidarNumero()
        {
            RuleFor(e => e.Numero)
                .NotNull().WithMessage("O número do RG não deve ser nulo")
                .NotEmpty().WithMessage("O número do RG não deve ser vazio")
                .MinimumLength(5).WithMessage("O número do RG deve ter no mínimo 05 caracteres")
                .MaximumLength(11).WithMessage("O número do RG deve ter no máximo 11 caracteres")
                .Matches(@"^[\d]{4,}[\w]{0,2}$").WithMessage("O número do RG informado é inválido");
        }

        private void ValidarUF()
        {
            RuleFor(e => e.UF)
               .Must(e => e.EstaValido()).WithMessage("A UF informada é inválida")
               .When(e => e.UF != null);
        }
    }
}
