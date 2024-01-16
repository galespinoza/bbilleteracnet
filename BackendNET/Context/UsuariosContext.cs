using Microsoft.EntityFrameworkCore;
using billetera.Models;

namespace billetera.Context;

public class UsuariosContext: DbContext
{
    public DbSet<Usuarios> Usuarios {get;set;}

    public UsuariosContext(DbContextOptions<UsuariosContext> options) :base(options) { }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        List<Usuarios> UsuariosInit = new List<Usuarios>();
        modelBuilder.HasDefaultSchema("BILLETERA");
        modelBuilder.Entity<Usuarios>(Usuarios=>
        {
            Usuarios.ToTable("Usuarios");
            Usuarios.HasKey(p=> p.ID);
            Usuarios.Property(p=> p.Nombre).IsRequired().HasMaxLength(200);
            Usuarios.Property(p=> p.Email).IsRequired(false);
            Usuarios.Property(p=> p.Contrasena).IsRequired();
            Usuarios.HasData(UsuariosInit);
        });

    }

}