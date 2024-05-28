namespace MinimalApi
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Turma { get; set; }

        public bool IsComplete { get; set; }
    }
}
