using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Support
{
    public class AppSettings
    {
        public static AppSettings Instance = new AppSettings();
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string LQConnectionString { get; set; }
    }

}
