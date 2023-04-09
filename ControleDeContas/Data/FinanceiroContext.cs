using ControleDeContas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContas.Data
{
    public class FinanceiroContext : DbContext
    {
        public FinanceiroContext(DbContextOptions options) : base(options) { }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<ControleDeContas.Models.Movimentacao>? Movimentacao { get; set; }
    }
}

