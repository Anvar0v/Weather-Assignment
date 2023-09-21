using Microsoft.EntityFrameworkCore;
using WeatherAssignment.Data.Models;

namespace WeatherAssignment.Data.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Weather> Weathers { get; set; }

}
