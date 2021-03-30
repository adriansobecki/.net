using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace net2
{
    public class MainProgram
    {
        static void Main(string[] args)
        {
            // tu wszystko działa i śmiga
            var myWeatherTask = getWeather("Konin");
            //myWeatherTask.Wait();

            Weather myWeather = myWeatherTask.Result;
            Console.WriteLine("Temp " + myWeather.main.temp + "K");
            Console.ReadLine();
        }

        public static async Task<Weather> getWeather(string city)
        {
            string call = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=08ba5dd31d0f7c44acd5ee3c8d364099";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(call);
            Weather result = JsonConvert.DeserializeObject<Weather>(response);
            return result;
        }
    }
}