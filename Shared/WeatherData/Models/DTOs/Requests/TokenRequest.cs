using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData.Models.DTOs.Requests
{
    public class TokenRequest
    {
        /// <summary>
        /// Token
        /// </summary>
        [Required]
        public string Token { get; set; }
        /// <summary>
        /// RefreshToken
        /// </summary>
        [Required]
        public string RefreshToken { get; set; }
    }
}
