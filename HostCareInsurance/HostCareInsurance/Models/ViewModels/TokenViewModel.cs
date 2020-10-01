using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostInsuranceAPI.Models.ViewModels
{
    public class TokenViewModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
        //public object CustomerId { get; set; }
        //public object AgentId { get; set; }
    }
}
