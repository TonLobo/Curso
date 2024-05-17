using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrimeiroProjeto.Models;

namespace PrimeiroProjeto.Data
{
    public class PrimeiroProjetoContext : DbContext
    {
        public PrimeiroProjetoContext (DbContextOptions<PrimeiroProjetoContext> options)
            : base(options)
        {
        }

        public DbSet<PrimeiroProjeto.Models.Movie> Movie { get; set; } = default!;
        public DbSet<PrimeiroProjeto.Models.Funcionario> Funcionario { get; set; } = default!;
    }
}
