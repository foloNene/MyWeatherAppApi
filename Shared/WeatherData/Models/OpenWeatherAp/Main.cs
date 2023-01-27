using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData.Models.OpenWeatherAp
{
    public class Main
    {
        /// <summary>
        /// City's main Temp
        /// </summary>
        public float Temp { get; set; }
        /// <summary>
        /// City's Main Float feels_like
        /// </summary>
        public float Feels_like { get; set; }
        /// <summary>
        /// City's Main Float Temp_min
        /// </summary>
        public float Temp_min { get; set; }
        /// <summary>
        /// City Main Float Temp_max
        /// </summary>
        public float Temp_max { get; set; }
        /// <summary>
        /// city Main Int Pressure
        /// </summary>
        public int Pressure { get; set; }
        /// <summary>
        /// City main's Humidity
        /// </summary>
        public int Humidity { get; set; }
        /// <summary>
        /// City's Sea-Level
        /// </summary>
        public int Sea_level { get; set; }
        /// <summary>
        /// City's Grnd_level
        /// </summary>
        public int Grnd_level { get; set; }
    }
}
