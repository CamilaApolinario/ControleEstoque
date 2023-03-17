using ControleEstoque.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Data
{
    public class ControleEstoqueContext : DbContext
    {
        public ControleEstoqueContext(DbContextOptions<ControleEstoqueContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
