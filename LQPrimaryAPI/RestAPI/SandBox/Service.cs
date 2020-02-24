using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LatamQuants.PrimaryAPI.SandBox
{
    public class Service
    {
        private const string m_Path = "C:\\Lucas\\devs\\LQPlatform\\LQPrimaryAPI\\RestAPI\\SandBox\\";
        public static R GetResponse<R>(string pMethodName)
        {
            R oReturn = default(R);
            string sFileName = pMethodName + "_Response.json";

            RestSharp.RestResponse oRestResponse = new RestSharp.RestResponse();
            oRestResponse.Content = File.ReadAllText(m_Path + sFileName);
            oReturn=JsonConvert.DeserializeObject<R>(oRestResponse.Content);

            return oReturn;
        }
    }
}
