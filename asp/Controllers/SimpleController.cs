using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
namespace asp.Controllers;


[ApiController]
[Route("[controller]/")]
public class SimpleController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello world!";
    }


    [HttpPost]
    public string Post([FromBody]IDictionary<string, string> data) 
    {
        
        // Console.WriteLine(data);
        var name = data["name"];
        return $"Hello {name}";
    }
}