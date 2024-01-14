namespace billetera.Models;
public class Deudas
{   
    public Guid ID {get;set;}
    public Guid UsuarioID {get;set;}
    public decimal Monto {get;set;}
    public string Descripcion {get;set;}
    public DateTime FechaDeuda {get;set;}
}