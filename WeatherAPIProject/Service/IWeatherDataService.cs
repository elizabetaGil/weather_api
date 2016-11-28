
namespace WeatherAPIProject
{
    public interface IWeatherDataService
    {
        WeatherData GetWeatherData(Location location);
    }
}
