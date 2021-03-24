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
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var json = File.ReadAllText(@"C:\Users\Adrian\source\repos\net2\net2\students.json");

            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
            foreach (var s in students)
                Console.WriteLine(s.studentId + ":\t" + s.studentName);
            */
            string city = Console.ReadLine();

            var task = api(city);
            task.Wait();

        }


        public static async Task<string> Test()
        {
            string call = "http://radoslaw.idzikowski.staff.iiar.pwr.wroc.pl/instruction/students.json";
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(call);
            List<Student> students = JsonConvert.DeserializeObject<List<Student>>(response);
            foreach (var s in students)
                Console.WriteLine(s.studentId + ":\t" + s.studentName);
            return response;
        }

        public static async Task<string> api(string city)
        {
            string call = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=08ba5dd31d0f7c44acd5ee3c8d364099";
            Console.WriteLine(call);
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(call);

            Weather result = JsonConvert.DeserializeObject<Weather>(response);

            //Console.WriteLine(result.main.temp);
            //Console.WriteLine(result.visibility);

            Console.WriteLine("In " + city+" is max " + (result.main.temp_max-273.15));
            return response;
        }


    }

    class Student
    {
        public int studentId { set; get; }
        public string studentName { set; get; }
    }

    class Weather
    {
        public int visibility { set; get; }
        public Main main { get; set; }


        public class Main
        {
            public double temp { set; get; }
            public double temp_min { set; get; }
            public double temp_max { set; get; }
            public double pressure { set; get; }

        }

    }
}