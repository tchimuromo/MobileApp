using HostcareInsuranceBrokers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostCareInsurance.Configs
{
    public class Config
    {
        public static string Username { get; set; }
        public static string Token { get; set; }
        public static string UserId { get; set; }
        public static string IPAddress { get; set; }
        public static double premiumRate { get; set; }
        public static Covertype CoverType { get; set; }

    }
}
