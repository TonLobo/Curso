using System.ComponentModel.DataAnnotations;

namespace ProjetoFilial.Models
{
    public class FilialGrupo
    {
        public int FilialGrupoID { get; set; }
        [Display(Name = "Nome Loja")]
        public string? Nome { get; set; }
        [Display(Name ="Gerente")]
        public string? GerenteFilial { get; set; }
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
        public int Cep {  get; set; }
        public string? Estado { get; set; }
        public double Faturamento { get; set; }
    }
}
