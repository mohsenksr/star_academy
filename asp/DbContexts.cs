using asp;
using Microsoft.EntityFrameworkCore;


public class WeatherContext : DbContext
{
    public DbSet<WeatherForecast> Forecasts { get; set; }

    public string DbPath { get; }

    public WeatherContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "weather.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}