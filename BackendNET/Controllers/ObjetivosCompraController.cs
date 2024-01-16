using Microsoft.AspNetCore.Mvc;
using billetera.Models;
using billetera.Services;

namespace billetera.Controllers;
//[ApiController]
[Route("api/[controller]")]
public class ObjetivosCompraController : ControllerBase
{
   private readonly ILogger<ObjetivosCompraController> _logger;
    IObjetivosCompraService ObjetivosCompraService;
    public ObjetivosCompraController(ILogger<ObjetivosCompraController> logger, IObjetivosCompraService service)
    {
        _logger = logger;
        ObjetivosCompraService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        //_logger.LogInformation("Saludando el mundo");
        return Ok(ObjetivosCompraService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] ObjetivosCompra ObjetivosCompra)
    {
        //_logger.LogInformation("Saludando el mundo");
        ObjetivosCompraService.Save(ObjetivosCompra);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ObjetivosCompra ObjetivosCompra)
    {
        //_logger.LogInformation("Saludando el mundo");
        ObjetivosCompraService.Update(id, ObjetivosCompra);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        //_logger.LogInformation("Saludando el mundo");
        ObjetivosCompraService.Delete(id);
        return Ok();
    }
}