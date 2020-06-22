using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatamQuants.Entities
{
    public class Strategy
    {
        [Key]
        public int StrategyID { get; set; }
        public string StrategyName { get; set; }
        public int Depth { get; set; }
        public bool Active { get; set; }
    }
}
