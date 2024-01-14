using billetera.Models;
using billetera.Context;

namespace billetera.Services;
public class DeudasService : IDeudasService
{
    DeudasContext context;

    public DeudasService(DeudasContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Deudas> Get()
    {
        return context.Deudass;
    }

    //public void Save(Categoria categoria){
    //    context.Add(categoria);
    //    context.SaveChanges();
    //}

    public async Task Save(Deudas Deudas)
    {

        context.Add(Deudas);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Deudas Deudas)
     {
        var DeudasActual = context.Deudass.Find(id);
        if (DeudasActual != null){
            Deudas.Monto = DeudasActual.Monto;
            Deudas.Descripcion = DeudasActual.Descripcion;
            Deudas.FechaDeuda = DeudasActual.FechaDeuda;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var DeudasActual = context.Deudass.Find(id);
        if (DeudasActual != null){
            context.Remove(DeudasActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface IDeudasService
{
    IEnumerable<Deudas> Get();
    Task Save(Deudas Deudas);
    Task Update(Guid id,Deudas Deudas);
    Task Delete(Guid id);

}