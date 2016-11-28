using System;

namespace WeatherAPIProject
{
    public class Sun
    {
        private DateTime sunset;
        private DateTime sunrise;

        public DateTime Set
        {
            get
            { return sunset; }
            set
            { sunset = value; }
        }

        public DateTime Rise
        {
            get
            { return sunrise; }
            set
            { sunrise = value; }
        }
    }
}
