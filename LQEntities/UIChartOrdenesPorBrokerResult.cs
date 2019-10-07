using System;
using System.Collections.Generic;
using System.Text;

namespace INOM.Entities
{
    /// <summary>
    /// Para graficar ordenes por Broker (Chart.js)
    /// </summary>
    public class UIChartOrdenesPorBrokerResult
    {
        public string Status { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
    }
}
