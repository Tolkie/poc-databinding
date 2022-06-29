using application.Application;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Converter;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly Context _context;

    public WeatherForecastController(Context context)
    {
        _context = context;
    }

    [HttpPut("test/{rule_name}")]
    public async Task<IActionResult> Put(
        [FromBody] BaseRuleRequest updatedRuleRequest)
    {
        Console.WriteLine(updatedRuleRequest.GetType());

        var response = _context.Demo(PutRuleConverter.Convert(updatedRuleRequest));
        return Ok(response);
    }
}