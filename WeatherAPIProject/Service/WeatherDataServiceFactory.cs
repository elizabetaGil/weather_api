using WeatherAPIProject.Service;

namespace WeatherAPIProject
{
    public enum WeatherWebServicesTypes { OPEN_WEATER_MAP, OTHER_SERIVCE };

    public class WeatherDataServiceFactory 
    {
        
        public IWeatherDataService GetWeatherDataService(WeatherWebServicesTypes weatherWebService)
        {
            OpenWeatherMapDataService openWeatherMapDataService = null;
            switch (weatherWebService)
            {
                case WeatherWebServicesTypes.OPEN_WEATER_MAP:
                    { 
                      openWeatherMapDataService = OpenWeatherMapDataService.getOpenWeatherMapDataService(new WebDownloader());
                      break;
                    }
                case WeatherWebServicesTypes.OTHER_SERIVCE:
                default:
                    throw new WeaterDataServiceExeption("Unsupported service type "+ weatherWebService.ToString());
            }
            return openWeatherMapDataService;
        }
    }
   


}
