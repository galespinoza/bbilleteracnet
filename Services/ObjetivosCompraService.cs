using billetera.Models;
using billetera.Context;

namespace billetera.Services;
public class ObjetivosCompraService : IObjetivosCompraService
{
    ObjetivosCompraContext context;

    public ObjetivosCompraService(ObjetivosCompraContext dbcontext)
    {
        context = dbcontext;
    }
    public IEnumerable<ObjetivosCompra> Get()
    {
        return context.ObjetivosCompras;
    }

    //public void Save(Categoria categoria){
    //    context.Add(categoria);
    //    context.SaveChanges();
    //}

    public async Task Save(ObjetivosCompra ObjetivosCompra)
    {

        context.Add(ObjetivosCompra);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,ObjetivosCompra ObjetivosCompra)
     {
        var ObjetivosCompraActual = context.ObjetivosCompras.Find(id);
        if (ObjetivosCompraActual != null){
            ObjetivosCompra.Producto = ObjetivosCompraActual.Producto;
            ObjetivosCompra.Precio = ObjetivosCompraActual.Precio;
            ObjetivosCompra.FechaObjetivo = ObjetivosCompraActual.FechaObjetivo;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var ObjetivosCompraActual = context.ObjetivosCompras.Find(id);
        if (ObjetivosCompraActual != null){
            context.Remove(ObjetivosCompraActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface IObjetivosCompraService
{
    IEnumerable<ObjetivosCompra> Get();
    Task Save(ObjetivosCompra ObjetivosCompra);
    Task Update(Guid id,ObjetivosCompra ObjetivosCompra);
    Task Delete(Guid id);

}