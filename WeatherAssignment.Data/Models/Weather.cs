using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAssignment.Data.Models;
public class Weather
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Generationtime_ms { get; set; }
    public int Utc_offset_seconds { get; set; }
    public string Timezone { get; set; }
    public string Timezone_abbreviation { get; set; }
    public double Elevation { get; set; }
    public virtual CurrentWeather Current_Weather { get; set; }
}
