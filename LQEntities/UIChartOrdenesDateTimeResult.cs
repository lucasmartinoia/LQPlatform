using System;
using System.Collections.Generic;
using System.Text;

namespace INOM.Entities
{
    /// <summary>
    /// Para graficar ordenes por DateTime (Chart.js)
    /// </summary>
    public class UIChartOrdenesDateTimeResult
    {
        public string Status { get; set; }
        public int Count { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string Mes { get; set;}
        public string Dia { get; set; }
        public string Hora { get; set; }
  
    }
}
