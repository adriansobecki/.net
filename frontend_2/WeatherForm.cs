using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using net2;

namespace frontend_2
{
    public partial class WeatherForm : Form
    {
        public WeatherForm()
        {
            InitializeComponent();

            var context = new databaseWeather();
            var data = (from w in context.databaseWeathers select w).ToList<database>();
            foreach (var w in data)
            {
                string toDisplay = w.name + " (" + w.datatime + ")";
                toDisplay += ": " + (w.temp - 273.15).ToString() + "°C";
                toDisplay += ": " + (w.description);
                listBox1.Items.Add(toDisplay);
            }
        }

        private Weather weather_thread(string city)
        {
            var myWeatherTask = MainProgram.getWeather(city);
            myWeatherTask.Wait();
            Weather myWeather = myWeatherTask.Result;

            return myWeather;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city = textBox2.Text;
            Weather myWeather=new Weather();
            Thread thread = new Thread(() => { myWeather = weather_thread(city); });
            thread.Start();
            thread.Join();

            string dataTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string toDisplay = city + " (" + dataTime + ")";
            toDisplay += ": "+(myWeather.main.temp- 273.15).ToString()+ "°C";
            toDisplay += ": " + (myWeather.weather[0].description);
            listBox1.Items.Add(toDisplay);

            var context = new databaseWeather();
            context.databaseWeathers.Add(new database { name = myWeather.name, datatime = dataTime, temp =myWeather.main.temp, description =myWeather.weather[0].description });
            context.SaveChanges();
        }
    }
}