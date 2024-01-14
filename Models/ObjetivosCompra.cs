namespace billetera.Models;
public class ObjetivosCompra
{   
    public Guid ID {get;set;}
    public Guid UsuarioID {get;set;}
    public string Producto {get;set;}
    public decimal Precio {get;set;}
    public DateTime FechaObjetivo {get;set;}
}