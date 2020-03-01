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
        private const string m_Path = "E:\\devs\\LatamQuants\\LQPlatform\\LQPrimaryAPI\\RestAPI\\SandBox\\";
        public static R GetResponse<R>(string pMethodName)
        {
            R oReturn = default(R);
            string sFileName = pMethodName + "_Response.json";

            RestSharp.RestResponse oRestResponse = new RestSharp.RestResponse();
            string sContent= File.ReadAllText(m_Path + sFileName);

            // Replace auto generated string.
            sContent = sContent.Replace("<<AUTO>>", RandomString(20));

            oRestResponse.Content = sContent;
            oReturn=JsonConvert.DeserializeObject<R>(oRestResponse.Content);

            return oReturn;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
