using Microsoft.EntityFrameworkCore;

namespace MinimalApi
{
    public class TodoDB : DbContext
	{
		public TodoDB(DbContextOptions<TodoDB> options)
			: base(options) { }

		public DbSet<Todo> Todos => Set<Todo>();
		public DbSet<Aluno> Alunos => Set<Aluno>();
	}
}
