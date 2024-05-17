using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFilial.Models;

namespace ProjetoFilial.Data
{
    public class ProjetoFilialContext : DbContext
    {
        public ProjetoFilialContext (DbContextOptions<ProjetoFilialContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoFilial.Models.FilialGrupo> FilialGrupo { get; set; } = default!;
    }
}
