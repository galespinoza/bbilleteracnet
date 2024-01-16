using Microsoft.AspNetCore.Mvc;
using billetera.Models;
using billetera.Services;

namespace billetera.Controllers;
//[ApiController]
[Route("api/[controller]")]
public class DeudasController : ControllerBase
{
   private readonly ILogger<DeudasController> _logger;
    IDeudasService DeudasService;
    public DeudasController(ILogger<DeudasController> logger, IDeudasService service)
    {
        _logger = logger;
        DeudasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        //_logger.LogInformation("Saludando el mundo");
        return Ok(DeudasService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Deudas Deudas)
    {
        //_logger.LogInformation("Saludando el mundo");
        DeudasService.Save(Deudas);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Deudas Deudas)
    {
        //_logger.LogInformation("Saludando el mundo");
        DeudasService.Update(id, Deudas);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        //_logger.LogInformation("Saludando el mundo");
        DeudasService.Delete(id);
        return Ok();
    }
}