using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData.Models.OpenWeatherAp
{
    public class WeatherResponse
    {
        /// <summary>
        /// Long and Lat of the Seacrh city
        /// </summary>
        public Coord coord { get; set; }
        /// <summary>
        /// City weather object Type
        /// </summary>
        public List <Weather> Weather { get; set; }
        /// <summary>
        /// City base
        /// </summary>
        public string Base { get; set; }
        /// <summary>
        /// City Main
        /// </summary>
        public Main Main { get; set; }
        /// <summary>
        /// City Visiblity
        /// </summary>
        public int Visibility { get; set; }
        /// <summary>
        /// city Wind Object Type
        /// </summary>
        public Wind Wind { get; set; }
        /// <summary>
        /// city Cloud Object Type
        /// </summary>
        public Cloud Clouds { get; set; }
        /// <summary>
        /// city weather Dt
        /// </summary>
        public int Dt { get; set; }
        /// <summary>
        /// City Sys object type
        /// </summary>
        public Sys Sys { get; set; }
        /// <summary>
        /// city time Zone
        /// </summary>
        public int Timezone { get; set; }
        /// <summary>
        /// city.s Int Id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// City's Name Intial
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// city cod Int 
        /// </summary>
        public int Cod { get; set; }


    }
}
