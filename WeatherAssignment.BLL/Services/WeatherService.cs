using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WeatherAssignment.BLL.ViewModels;
using WeatherAssignment.Data.Data;
using WeatherAssignment.Data.Models;

namespace WeatherAssignment.BLL.Services;
public class WeatherService : IWeatherService
{
    private readonly AppDbContext _context;

    public WeatherService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<WeatherViewModel>> GetAllWeatherAsync()
    {
        var weatherDatas = await _context.Weathers.ToListAsync();
        return weatherDatas.Adapt<List<WeatherViewModel>>();
    }

    public async Task<WeatherViewModel> GetWeatherAsync(Guid id)
    {
        var weatherData = await _context.Weathers.FirstOrDefaultAsync(w => w.Id == id);

        if (weatherData is not null)
            return weatherData.Adapt<WeatherViewModel>();

        throw new Exception("There is no such weather data with id that is passed!");
    }

    public async Task SeedRecentDataAsync()
    {
        var _client = new HttpClient();
        string requestURL = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current_weather=true";
        var retrievedActualData = await _client.GetFromJsonAsync<Weather>(requestURL);

        if (retrievedActualData is null)
            throw new Exception("Data is null");

        await _context.Weathers.AddAsync(retrievedActualData);
        await _context.SaveChangesAsync();
    }
}
