using System.ComponentModel.DataAnnotations.Schema;

namespace billetera.Models;
public class Usuarios
{   
    [Column("ID")]
    public Guid ID {get;set;}
    [Column("NOMBRE")]
    public string Nombre {get;set;}
    [Column("EMAIL")]
    public string Email {get;set;}
    [Column("CONTRASENA")]
    public string Contrasena {get;set;}
}