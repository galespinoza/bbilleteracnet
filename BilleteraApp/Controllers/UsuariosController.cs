using Microsoft.AspNetCore.Mvc;
using billetera.Models;
using billetera.Services;

namespace billetera.Controllers;
//[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
   private readonly ILogger<UsuariosController> _logger;
    IUsuariosService UsuariosService;
    public UsuariosController(ILogger<UsuariosController> logger, IUsuariosService service)
    {
        _logger = logger;
        UsuariosService = service;
    }

    [HttpGet]
    [Route("listausuario")]
    public IActionResult ListaUsuario()
    {
        //_logger.LogInformation("Saludando el mundo");
        return Ok(UsuariosService.Get());
    }

    [HttpPost]
    [Route("guardausuario")]
    public IActionResult GuardaUsuario([FromBody] Usuarios usuarios)
    {
        //_logger.LogInformation("Saludando el mundo");
        UsuariosService.Save(usuarios);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("actualizausuario")]
    public IActionResult ActualizaUsuario(Guid id, [FromBody] Usuarios usuarios)
    {
        //_logger.LogInformation("Saludando el mundo");
        UsuariosService.Update(id, usuarios);
        return Ok();
    }

    [HttpDelete("{id}")]
     [Route("eliminausuario")]
    public IActionResult EliminaUsuario(Guid id)
    {
        //_logger.LogInformation("Saludando el mundo");
        UsuariosService.Delete(id);
        return Ok();
    }
}