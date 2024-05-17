using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AvaliacaoMvc.Models;

namespace AvaliacaoMvc.Data
{
    public class AvaliacaoMvcContext : DbContext
    {
        public AvaliacaoMvcContext (DbContextOptions<AvaliacaoMvcContext> options)
            : base(options)
        {
        }

        public DbSet<AvaliacaoMvc.Models.CadAluno> CadAluno { get; set; } = default!;
    }
}
