public class Pagos
{   
    public Guid ID {get;set;}
    public Guid DeudaID {get;set;}
    public decimal Monto {get;set;}
     public string Descripcion {get;set;}
    public DateTime FechaPago {get;set;}
}