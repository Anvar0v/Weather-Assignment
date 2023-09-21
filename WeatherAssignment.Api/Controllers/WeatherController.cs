using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WeatherAssignment.BLL.Services;
using WeatherAssignment.BLL.ViewModels;

namespace WeatherAssignment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpPost("/wather-seaed_data")]
    public async Task<IActionResult> SeedRecentData()
    {
        await _weatherService.SeedRecentDataAsync();
        return Ok();
    }

    [HttpGet("/weather")]
    [ProducesResponseType(typeof(List<WeatherViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWeatherDatas()
        => Ok(await _weatherService.GetAllWeatherAsync());

    [HttpGet("/weather/id")]
    [ProducesResponseType(typeof(WeatherViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWeatherDataById(Guid id)
        => Ok(await _weatherService.GetWeatherAsync(id));
}