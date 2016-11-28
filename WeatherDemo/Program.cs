using System;
using WeatherAPIProject;
namespace WeatherDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IWeatherDataService weatherDataService = new WeatherDataServiceFactory().GetWeatherDataService(WeatherWebServicesTypes.OPEN_WEATER_MAP);
            }
            catch (WeaterDataServiceExeption ex)
            {
                Console.WriteLine("error " + ex.Message);
            }

            try
            {
                Location location = new Location("TelAviv");
                IWeatherDataService service = new WeatherDataServiceFactory().GetWeatherDataService(WeatherWebServicesTypes.OPEN_WEATER_MAP);
                var result = service.GetWeatherData(location);
                printWeather(result,location);
            }
            catch (WeaterDataServiceExeption ex)
            {
                Console.WriteLine("WeaterDataServiceExeption error" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
        }

        private static void printWeather(WeatherData result,Location location)
        {
            Console.WriteLine("Weather in "+ location.LocationName + ":");
            Console.WriteLine("Temperature (on "+result.Unit + " unit):");
            Console.WriteLine(result.Temperature);
            Console.WriteLine("Cloud:");
            Console.WriteLine(result.Cloud.Name);
            Console.WriteLine(result.Cloud.Value);
            Console.WriteLine("Humidity:");
            Console.WriteLine(result.Humidity);
            Console.WriteLine("Pressure:");
            Console.WriteLine(result.Pressure);
            Console.WriteLine("Sun rise:");
            Console.WriteLine(result.Sun.Rise);
            Console.WriteLine("Sun set:");
            Console.WriteLine(result.Sun.Set);
        }
    }
}
