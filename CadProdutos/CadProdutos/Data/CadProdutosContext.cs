using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadProdutos.Models;

namespace CadProdutos.Data
{
    public class CadProdutosContext : DbContext
    {
        public CadProdutosContext (DbContextOptions<CadProdutosContext> options)
            : base(options)
        {
        }

        public DbSet<CadProdutos.Models.Produto> Produto { get; set; } = default!;
    }
}
