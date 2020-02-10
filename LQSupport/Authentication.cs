using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.Support
{
    public class Authentication
    {
        public enum AuthenticationMode
        {
            Basic = 0,
            Token = 1,
        }

        public string User { get; set; }
        public string Password { get; set; }
        public string TokenKey { get; set; }
        public string TokenValue { get; set; }
        public AuthenticationMode Mode { get; set; }
    }
}
