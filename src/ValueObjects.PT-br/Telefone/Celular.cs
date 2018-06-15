namespace ValueObjects.PT_br.Telefone
{
    public class Celular : TelefoneFixo
    {
        public Celular(string ddd, string numero) : base(ddd, numero)
        {
        }
        //TODO: override Validar numero
    }
}
