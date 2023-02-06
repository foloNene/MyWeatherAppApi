using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData.Models.DTOs.Requests
{
    public class VerificationRequest
    {
        /// <summary>
        /// UserName
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Token { get; set; }

    }
}
