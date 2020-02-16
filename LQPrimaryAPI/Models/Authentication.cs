using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public class Authentication
    {
       public string User { get; set; }
        public string Password { get; set; }
        public string TokenKey { get; set; }
        public string TokenValue { get; set; }
    }
}
