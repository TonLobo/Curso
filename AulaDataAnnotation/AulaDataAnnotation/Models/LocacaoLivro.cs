using System.ComponentModel.DataAnnotations;

namespace AulaDataAnnotation.Models
{
    public class LocacaoLivro
    {
        public int LocacaoLivroID { get; set; }
        [Display(Name = "Nome do Livro")]
        public string? NomeLivro { get; set; }
        public string? Tipo { get; set; }
        [Display(Name = "Nome do Cliente")]
        public string? Nome { get; set; }
        public int CPF { get; set; }
        [Display(Name = "Data de Saída")]
        public DateTime DtSaida { get; set; }
        [Display(Name = "Data de Retorno")]
        public DateTime DtRetorno { get; set; }
    }
}
