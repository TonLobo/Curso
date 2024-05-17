namespace Locadora.Models
{
    public class LocaLivro
    {
        public int LivroID { get; set; }
        public string? NomeLivro { get; set;}
        public string? Tipo { get; set; }
        public string? Nome { get; set; }
        public int CPF { get; set; }
        public DateTime DtSaida { get; set; }
        public DateTime DtRetorno { get; set; }
    }
}
