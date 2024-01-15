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
    public IActionResult Get()
    {
        //_logger.LogInformation("Saludando el mundo");
        return Ok(UsuariosService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Usuarios Usuarios)
    {
        //_logger.LogInformation("Saludando el mundo");
        UsuariosService.Save(Usuarios);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Usuarios Usuarios)
    {
        //_logger.LogInformation("Saludando el mundo");
        UsuariosService.Update(id, Usuarios);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        //_logger.LogInformation("Saludando el mundo");
        UsuariosService.Delete(id);
        return Ok();
    }
}