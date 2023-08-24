using System.Text.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace asp.Controllers;


[ApiController]
[Route("[controller]/")]
public class WeatherDBActionController : ControllerBase
{
    private readonly WeatherContext _weatherContext;

    public WeatherDBActionController(WeatherContext weatherContext)
    {
        _weatherContext = weatherContext ?? throw new ArgumentNullException(nameof(weatherContext));
    }

    [HttpGet]
    public IActionResult Get(int id)
    { 
        var forecast = _weatherContext.Forecasts.Find(id);
        return forecast == null ? NotFound() : Ok(forecast);
    }

    [HttpPost]
    public IActionResult Post([FromBody]WeatherForecast forecast) 
    {
        try {
            _weatherContext.Add(forecast);
            _weatherContext.SaveChanges();
            return Ok();
        }
        catch (Exception ex){
            return BadRequest();
        }
    }
}