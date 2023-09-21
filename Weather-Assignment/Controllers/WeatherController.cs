using Microsoft.AspNetCore.Mvc;
using WeatherAssignment.BLL.Services;

namespace Weather_Assignment.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpPost]
    public async Task<IActionResult> SeedRecentData()
    {
        await _weatherService.SeedRecentDataAsync();
        return Ok();
    }
}