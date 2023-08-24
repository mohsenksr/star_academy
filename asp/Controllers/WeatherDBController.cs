using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace asp.Controllers;


[ApiController]
[Route("[controller]/")]
public class WeatherDBController : ControllerBase
{
    private readonly WeatherContext _weatherContext;

    public WeatherDBController(WeatherContext weatherContext)
    {
        _weatherContext = weatherContext ?? throw new ArgumentNullException(nameof(weatherContext));
    }

    [HttpGet]
    public IQueryable<WeatherForecast> Get()
    { 
        return _weatherContext.Forecasts.ToList().AsQueryable();
    }

    [HttpPost]
    public string Post([FromBody]WeatherForecast forecast) 
    {
        _weatherContext.Add(forecast);
        _weatherContext.SaveChanges();

        return "OK";
    }
}