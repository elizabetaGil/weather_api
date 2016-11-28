using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherAPIProject.Service;

namespace WeatherAPIProject.Tests
{
    [TestClass()]
    public class OpenWeatherMapDataServiceTests
    {
    
        [TestMethod()]
        public void GetWeatherDataTest()
        {
            FakeWebDownloader fakeDownloader = new FakeWebDownloader();
            fakeDownloader.Result = @"
<current><city id=""295620"" name=""Ashqelon""><coord lon=""34.57"" lat=""31.67""></coord><country>IL</country><sun rise=""2016 - 10 - 02T03: 36:33"" set=""2016 - 10 - 02T15: 24:38""></sun></city><temperature value=""312.25"" min=""312.25"" max=""312.25"" unit=""kelvin""></temperature><humidity value=""17"" unit="" % ""></humidity><pressure value=""1012.831"" unit=""hPa""></pressure><wind><speed value=""4.56"" name=""Gentle Breeze""></speed><gusts></gusts><direction value=""94.5044"" code=""E"" name=""East""></direction></wind><clouds value=""0"" name=""clear sky""></clouds><visibility></visibility><precipitation mode=""no""></precipitation><weather number=""800"" value=""clear sky"" icon=""01d""></weather><lastupdate value=""2016 - 10 - 02T09: 34:36""></lastupdate></current>
";
            WeatherData expected = new WeatherData();
            expected.Cloud = new Cloud();
            expected.Cloud.Name = "clear sky";
            expected.Cloud.Value = 0;
            expected.Humidity = "17%";
            expected.LastUpdate = new DateTime(2016, 10, 02, 09, 34, 36);
            expected.Pressure = 1012.831F;
            expected.Sun = new Sun();
            expected.Sun.Rise = DateTime.Parse("2016 - 10 - 02T03: 36:33");
            expected.Sun.Set = DateTime.Parse("2016 - 10 - 02T15: 24:38");
            expected.Temperature = 312.25F;
            expected.Unit = "kelvin";
            expected.Wind = new Wind();
            expected.Wind.Name = "Gentle Breeze";
            expected.Wind.Speed = 4.56F;

            OpenWeatherMapDataService openWeatherMapDataService = OpenWeatherMapDataService.getOpenWeatherMapDataService(fakeDownloader);
            Location location = new Location("Ashqelon");

            WeatherData actual = openWeatherMapDataService.GetWeatherData(location);

            Assert.AreEqual(actual.Cloud.Name, expected.Cloud.Name);
            Assert.AreEqual(actual.Cloud.Value, expected.Cloud.Value);
            Assert.AreEqual(actual.Humidity, expected.Humidity);
            Assert.AreEqual(actual.LastUpdate, expected.LastUpdate);
            Assert.AreEqual(actual.Pressure, expected.Pressure);
            Assert.AreEqual(actual.Sun.Rise, expected.Sun.Rise);
            Assert.AreEqual(actual.Sun.Set, expected.Sun.Set);
            Assert.AreEqual(actual.Temperature, expected.Temperature);
            Assert.AreEqual(actual.Unit, expected.Unit);
            Assert.AreEqual(actual.Wind.Name, expected.Wind.Name);
            Assert.AreEqual(actual.Wind.Speed, expected.Wind.Speed);
            
        }
    }

    public class FakeWebDownloader : IWebDownloader
    {

        public string Result;

        public string Download(string url)
        {
            return Result;
        }
    }
}