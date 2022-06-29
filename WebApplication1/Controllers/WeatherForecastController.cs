using Microsoft.AspNetCore.Mvc;
using WebApplication1.Application;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    [HttpPut("test/{rule_name}")]
    public async Task<IActionResult> Put(
        [FromBody] BaseRule updatedRule, string rule_name)
    {
        Console.WriteLine(updatedRule.GetType());

        var context = new Context();

        context.demo(updatedRule);
        
        return Ok(updatedRule);
    }
}