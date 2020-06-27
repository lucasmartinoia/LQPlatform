using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class MonitorSetting
    {
        [Key]
        public int MonitorSettingID { get; set; }
        public string CFICodes { get; set; }
        public string Segments { get; set; }

        public static List<MonitorSetting> GetList()
        {
            List<MonitorSetting> colReturn = new List<MonitorSetting>();

            using (var db = new DBContext())
            {
                colReturn = db.MonitorSettings.ToList();
            }

            return colReturn;
        }
    }
}
