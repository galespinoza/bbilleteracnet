using System.ComponentModel.DataAnnotations.Schema;

namespace billetera.Models;
public class Usuarios
{   
    //[Column("ID")]
    public Guid ID {get;set;}
    public string? Nombre {get;set;}
    public string? Email {get;set;}
    public string? Contrasena {get;set;}
}