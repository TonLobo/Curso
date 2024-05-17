namespace AulaDtAnot.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string? Nome { get; set; }
        public DateTime DtNasc { get; set; }
        public double Salario { get; set; }
        public string? Senha { get; set; }
        public string? ConfirmaSenha { get; set;}
    }
}
