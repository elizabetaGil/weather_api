using System;
using System.Xml.Linq;
using WeatherAPIProject.Service;

namespace WeatherAPIProject
{
    public class OpenWeatherMapDataService : IWeatherDataService 
    {
        private IWebDownloader webDownloader;
        private static OpenWeatherMapDataService instance;

        //singleton design pattern
        public static OpenWeatherMapDataService getOpenWeatherMapDataService(IWebDownloader webDownloader)
        {
            if(instance == null){
                instance = new OpenWeatherMapDataService(webDownloader);
            }
            return instance;
        }

        private OpenWeatherMapDataService(IWebDownloader webDownloader)
        {
            this.webDownloader = webDownloader;
        }

        public WeatherData GetWeatherData(Location location)
        {
            string data = null;
            try
            {
                data = DownloadWeatherXml("http://api.openweathermap.org/data/2.5/weather?q=" + location.LocationName + "&mode=xml&APPID=a0dfc9db3d55a51591963a9b491c51e9");
            }
            catch (Exception ex)
            {
                throw new WeaterDataServiceExeption("Web error " + ex.GetType().Name + " " + ex.Message);
            }

            try
            {
                //parsing data from xml
                string myXML = @data;
                XDocument xdoc = new XDocument();
                xdoc = XDocument.Parse(myXML);
                XElement xelement = XElement.Parse(data);
                WeatherData weatherData = new WeatherData();
                weatherData.Sun = new Sun();
                weatherData.Sun.Rise = DateTime.Parse(xelement.Element("city").Element("sun").Attribute("rise").Value);
                weatherData.Sun.Set = DateTime.Parse(xelement.Element("city").Element("sun").Attribute("set").Value);
                weatherData.Temperature = float.Parse(xelement.Element("temperature").Attribute("value").Value);
                weatherData.Unit = xelement.Element("temperature").Attribute("unit").Value;
                weatherData.Humidity = xelement.Element("humidity").Attribute("value").Value + "%";
                weatherData.Pressure = float.Parse(xelement.Element("pressure").Attribute("value").Value);
                Wind wind = new Wind();
                wind.Speed = float.Parse(xelement.Element("wind").Element("speed").Attribute("value").Value);
                wind.Name = xelement.Element("wind").Element("speed").Attribute("name").Value;
                weatherData.Wind = wind;
                Cloud clouds = new Cloud();
                clouds.Value = float.Parse(xelement.Element("clouds").Attribute("value").Value);
                clouds.Name = xelement.Element("clouds").Attribute("name").Value;
                weatherData.Cloud = clouds;
                weatherData.LastUpdate = DateTime.Parse(xelement.Element("lastupdate").Attribute("value").Value);
                return weatherData;
            }
            catch (Exception ex)
            {
                throw new WeaterDataServiceExeption("Error "+ex.GetType().Name+" " + ex.Message);
            }
        }
        
        private string DownloadWeatherXml(string url)
        {
            return webDownloader.Download(url);
        }
    }
    
}
