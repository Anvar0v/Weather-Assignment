using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAssignment.BLL.ViewModels;

namespace WeatherAssignment.BLL.Services;
public interface IWeatherService
{
    Task SeedRecentDataAsync();
    Task<WeatherViewModel> GetWeatherAsync(Guid id);
    Task<List<WeatherViewModel>> GetAllWeatherAsync();
}
