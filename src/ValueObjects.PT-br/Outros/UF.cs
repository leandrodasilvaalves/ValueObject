using FluentValidation;

namespace ValueObjects.PT_br.Outros
{
    public class UF : ValueObjectBase<UF>
    {
        public UF(string uf, string nomeUf)
        {
            Uf = uf;
            NomeUf = nomeUf;
        }

        public string Uf { get; private set; }
        public string NomeUf { get; private set; }

        protected override void Validar()
        {
            ValidarUf();
            ValildarNomeUf();

            ResultadoValidacao = Validate(this);
        }

        private void ValidarUf()
        {
            RuleFor(e => e.Uf)
                .MinimumLength(2).WithMessage("A UF deve ter 02 caracteres")
                .MaximumLength(2).WithMessage("A UF deve ter 02 caracteres")
                .NotEmpty().WithMessage("A UF não pode ser vazia")
                .NotNull().WithMessage("A UF não pode ser nula")
                .Must(EstaNaListaUf).WithMessage("A UF informada é inválida");
        }

        private void ValildarNomeUf()
        {
            RuleFor(e => e.NomeUf)
                .NotNull().WithMessage("O nome da UF não pode ser nulo")
                .NotEmpty().WithMessage("O nome da UF não pode ser vazio")
                .Must(EstaNaListaNomeUf).WithMessage("O nome da UF informado é inválido");
        }

        private bool EstaNaListaUf(string uf)
        {
            if (uf == null)
                return false;

            string UFs = "AC;AL;AP;AM;BA;CE;DF;ES;GO;MA;MT;MS;MG;PA;PB;PR;PE;PI;RJ;RN;RS;RO;RR;SC;SP;SE;TO";
            return UFs.Contains(uf);
        }

        private bool EstaNaListaNomeUf(string nomeUf)
        {
            if (nomeUf == null)
                return false;

            string nomesUfs = "Acre;Alagoas;Amapá;Amazonas;Bahia;Ceará;Distrito Federal;Espírito Santo" +
                "Goiás;Maranhão;Mato Grosso;Mato Grosso do Sul;Minas Gerais;Pará;Paraíba;Paraná" +
                "Pernambuco;Piauí;Rio de Janeiro;Rio Grande do Norte;Rio Grande do Sul;Rondônia;Roraima" +
                "Santa Catarina;São Paulo;Sergipe;Tocantins;";

            return nomesUfs.Contains(nomeUf);
        }
    }
}
