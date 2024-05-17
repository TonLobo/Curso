using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AulaDataAnnotation.Models;

namespace AulaDataAnnotation.Data
{
    public class AulaDataAnnotationContext : DbContext
    {
        public AulaDataAnnotationContext (DbContextOptions<AulaDataAnnotationContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; } = default!;
        public DbSet<AulaDataAnnotation.Models.LocacaoLivro> LocacaoLivro { get; set; } = default!;
    }
}
