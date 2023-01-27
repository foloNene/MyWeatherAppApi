using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData.Models.OpenWeatherAp
{
    public class Wind
    {
        /// <summary>
        /// city's wind speed
        /// </summary>
        public float Speed { get; set; }
        /// <summary>
        /// city's wind Deg
        /// </summary>
        public int Deg { get; set; }
        /// <summary>
        /// City's Wind Gust
        /// </summary>
        public float Gust { get; set; }

    }
}
