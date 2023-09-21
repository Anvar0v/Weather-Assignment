using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAssignment.Data.Models;
public class CurrentWeather
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public double Temperature { get; set; }
    public double Windspeed { get; set; }
    public int WindDirection { get; set; }
    public int WeatherCode { get; set; }
    public int is_Day { get; set; }
    public Guid WeatherId { get; set; }
    [ForeignKey(nameof(WeatherId))]
    public virtual Weather Weather { get; set; }
}
