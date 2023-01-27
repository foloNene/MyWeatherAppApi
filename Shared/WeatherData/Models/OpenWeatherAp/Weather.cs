using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData.Models.OpenWeatherAp
{
    public class Weather
    {
        /// <summary>
        /// Weather Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Weather Main
        /// </summary>
        public string Main { get; set; }
        /// <summary>
        /// Weather's Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// weather Icon
        /// </summary>
        public string Icon { get; set; }
    }
}
