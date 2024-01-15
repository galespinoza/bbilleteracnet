using Microsoft.EntityFrameworkCore;
using billetera.Models;

namespace billetera.Context;

public class ObjetivosCompraContext: DbContext
{
    public DbSet<ObjetivosCompra> ObjetivosCompra {get;set;}

    public ObjetivosCompraContext(DbContextOptions<ObjetivosCompraContext> options) :base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        List<ObjetivosCompra> ObjetivosCompraInit = new List<ObjetivosCompra>();

        modelBuilder.Entity<ObjetivosCompra>(ObjetivosCompra=>
        {
            ObjetivosCompra.ToTable("ObjetivosCompra");
            ObjetivosCompra.HasKey(p=> p.ID);
            ObjetivosCompra.HasKey(p=> p.UsuarioID);
            ObjetivosCompra.HasKey(p=> p.Producto);
            ObjetivosCompra.HasKey(p=> p.Precio);
            ObjetivosCompra.HasKey(p=> p.FechaObjetivo);
            ObjetivosCompra.HasData(ObjetivosCompraInit);
        });

    }

}