using System.IO;
using System.Net;


namespace WeatherAPIProject.Service
{

    public class WebDownloader : IWebDownloader
    {
        /// <summary>
        /// Reading (downloading) the weather data from a website.
        /// </summary>
        /// <param name="url">The url address</param>
        /// <returns>String of data</returns>
        public string Download(string url)
        {
            string str = string.Empty;
            WebClient client = new WebClient();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            {
                str = reader.ReadToEnd();
            }
 
            return str;
        }
    }
}
