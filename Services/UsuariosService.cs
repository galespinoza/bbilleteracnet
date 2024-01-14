using billetera.Models;
using billetera.Context;

namespace billetera.Services;
public class UsuariosService : IUsuariosService
{
    UsuariosContext context;

    public UsuariosService(UsuariosContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Usuarios> Get()
    {
        return context.Usuarioss;
    }

    //public void Save(Categoria categoria){
    //    context.Add(categoria);
    //    context.SaveChanges();
    //}

    public async Task Save(Usuarios Usuarios)
    {

        context.Add(Usuarios);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Usuarios Usuarios)
     {
        var UsuariosActual = context.Usuarioss.Find(id);
        if (UsuariosActual != null){
            Usuarios.Nombre = UsuariosActual.Nombre;
            Usuarios.Email = UsuariosActual.Email;
            Usuarios.Contrasena = UsuariosActual.Contrasena;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var UsuariosActual = context.Usuarioss.Find(id);
        if (UsuariosActual != null){
            context.Remove(UsuariosActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface IUsuariosService
{
    IEnumerable<Usuarios> Get();
    Task Save(Usuarios Usuarios);
    Task Update(Guid id,Usuarios Usuarios);
    Task Delete(Guid id);

}