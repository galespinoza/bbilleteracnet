using billetera.Models;
using billetera.Context;

namespace billetera.Services;
public class PagosService : IPagosService
{
    PagosContext context;

    public PagosService(PagosContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<Pagos> Get()
    {
        return context.Pagos;
    }

    //public void Save(Categoria categoria){
    //    context.Add(categoria);
    //    context.SaveChanges();
    //}

    public async Task Save(Pagos Pagos)
    {

        context.Add(Pagos);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Pagos Pagos)
     {
        var PagosActual = context.Pagos.Find(id);
        if (PagosActual != null){
            Pagos.Monto = PagosActual.Monto;
            Pagos.FechaPago = PagosActual.FechaPago;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var PagosActual = context.Pagos.Find(id);
        if (PagosActual != null){
            context.Remove(PagosActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface IPagosService
{
    IEnumerable<Pagos> Get();
    Task Save(Pagos Pagos);
    Task Update(Guid id,Pagos Pagos);
    Task Delete(Guid id);

}