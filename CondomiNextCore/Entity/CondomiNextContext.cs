using CondomiNextCore.Table;
using Microsoft.EntityFrameworkCore;

public class CondomiNextContext : DbContext
{
    public DbSet<Morador> Moradores { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CondomiNext;Trusted_Connection=true");
    }

}