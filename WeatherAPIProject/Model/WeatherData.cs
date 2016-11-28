using System;

namespace WeatherAPIProject
{
    public class WeatherData
    {
        public float Temperature { get; set; }
        public string Unit { get; set; }
        public string Humidity { get; set; }
        public float Pressure { get; set; }
        public Wind Wind { get; set; }
        public Cloud Cloud { get; set; }
        public Sun Sun { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
