using System.ComponentModel.DataAnnotations;

namespace AvaliacaoMvc.Models
{
    public class CadAluno
    {
        public int CadAlunoID { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
        public string? Cep { get; set; }
        public string? Turma { get; set; }
    }
}
