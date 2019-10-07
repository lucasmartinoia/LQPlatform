using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class ChartOrdenesSearch
    {
        public DateTime fechaDesdeChartPie { get; set; }
        public DateTime fechaHastaChartPie { get; set; }
        [StringLength(50)]
        public string channelIDChartPie { get; set; }
        public string orderTypeChartPie { get; set; }
    }
}
