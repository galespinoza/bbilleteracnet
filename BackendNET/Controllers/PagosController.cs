using Microsoft.AspNetCore.Mvc;
using billetera.Models;
using billetera.Services;

namespace billetera.Controllers;
//[ApiController]
[Route("api/[controller]")]
public class PagosController : ControllerBase
{
   private readonly ILogger<PagosController> _logger;
    IPagosService PagosService;
    public PagosController(ILogger<PagosController> logger, IPagosService service)
    {
        _logger = logger;
        PagosService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        //_logger.LogInformation("Saludando el mundo");
        return Ok(PagosService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Pagos Pagos)
    {
        //_logger.LogInformation("Saludando el mundo");
        PagosService.Save(Pagos);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Pagos Pagos)
    {
        //_logger.LogInformation("Saludando el mundo");
        PagosService.Update(id, Pagos);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        //_logger.LogInformation("Saludando el mundo");
        PagosService.Delete(id);
        return Ok();
    }
}