using System.ComponentModel.DataAnnotations;

namespace PrimeiroProjeto.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string? NomeFuncionario { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate{ get; set; }
        public string? Cargo { get; set; }

        public double Salario { get; set; }

    }
}
