using System;

namespace WeatherAPIProject
{
    public class WeaterDataServiceExeption:Exception 
    {
        private string _message;

        public WeaterDataServiceExeption(string message)
        {
            _message  = message;
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }

        public override string ToString()
        {
            return string.Format("Weater data service exeption: {0}", Message);
        }

    }
}
