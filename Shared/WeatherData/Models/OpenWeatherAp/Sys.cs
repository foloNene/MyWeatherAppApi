using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData.Models.OpenWeatherAp
{
    public class Sys
    {
        /// <summary>
        /// City Name
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// city's Sunrise
        /// </summary>
        public int Sunrise { get; set; }
        /// <summary>
        /// city's sunset
        /// </summary>
        public int Sunset { get; set; }

    }
}
