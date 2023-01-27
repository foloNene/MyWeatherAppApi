using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData.Models.OpenWeatherAp
{
    public class Coord
    {
        /// <summary>
        /// city's Coord Float Long
        /// </summary>
        public float Lon { get; set; }

        /// <summary>
        /// City's Lat Float Lat
        /// </summary>
        public float Lat { get; set; }
    }
}
