using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAssignment.BLL.ViewModels;
public class CurrentWeatherViewModel
{
    public Guid Id { get; set; }
    public double Temperature { get; set; }
    public double Windspeed { get; set; }
    public int WindDirection { get; set; }
    public int is_Day { get; set; }
}
