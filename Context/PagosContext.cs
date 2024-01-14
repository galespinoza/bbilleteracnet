using Microsoft.EntityFrameworkCore;
using billetera.Models;

namespace billetera.Context;

public class PagosContext: DbContext
{
    public DbSet<Pagos> Pagoss {get;set;}

    public PagosContext(DbContextOptions<PagosContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        List<Pagos> PagosInit = new List<Pagos>();

        modelBuilder.Entity<Pagos>(Pagos=>
        {
            Pagos.ToTable("Pagos");
            Pagos.HasKey(p=> p.ID);
            Pagos.HasKey(p=> p.DeudaID);
            Pagos.HasKey(p=> p.Monto);
            Pagos.HasKey(p=> p.FechaPago);
            Pagos.HasData(PagosInit);
        });

    }

}