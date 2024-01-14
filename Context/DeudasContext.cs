using Microsoft.EntityFrameworkCore;
using billetera.Models;

namespace billetera.Context;

public class DeudasContext: DbContext
{
    public DbSet<Deudas> Deudass {get;set;}

    public DeudasContext(DbContextOptions<DeudasContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        List<Deudas> DeudasInit = new List<Deudas>();

        modelBuilder.Entity<Deudas>(Deudas=>
        {
            Deudas.ToTable("Deudas");
            Deudas.HasKey(p=> p.ID);
            Deudas.HasKey(p=> p.UsuarioID);
            Deudas.HasKey(p=> p.Monto);
            Deudas.HasKey(p=> p.Descripcion);
            Deudas.Property(p=> p.FechaDeuda).IsRequired();
            Deudas.HasData(DeudasInit);
        });

    }

}