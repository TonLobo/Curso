using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AulaDtAnot.Models;

namespace AulaDtAnot.Data
{
    public class AulaDtAnotContext : DbContext
    {
        public AulaDtAnotContext (DbContextOptions<AulaDtAnotContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; } = default!;
    }
}
