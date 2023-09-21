namespace WeatherAssignment.BLL.ViewModels;

public class WeatherViewModel
{
    public Guid Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public CurrentWeatherViewModel Current_Weather { get; set; }
}
