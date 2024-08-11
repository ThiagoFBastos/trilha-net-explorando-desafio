namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; private set; } = [];
        public Suite? Suite { get; private set; }
        public int DiasReservados { get; private set; } = 0;

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if(Suite == null)
                throw new Exception("Suite não cadastrada!");
            else if (Suite.Capacidade >= hospedes.Count())
                Hospedes = hospedes;
            else
                throw new ArgumentException("A capacidade da suíte é insuficiente!");
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count();
        }

        public decimal CalcularValorDiaria()
        {
            if(Suite == null)
                throw new Exception("Suíte não cadastrada!");

            decimal valor = Suite.ValorDiaria * DiasReservados;

            if(DiasReservados >= 10)
                valor *= 0.9M;

            return valor;
        }
    }
}