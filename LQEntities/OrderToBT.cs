using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using INOM.Support;
using System.Collections.Generic;
using System.Linq;

namespace INOM.Entities
{
    public class OrderToBT
    {
        [Key]
        public int OrderToBTID { get; set; }
        public int OrderID { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string OrderStatus { get; set; }
        public string StatusComunication { get; set; }
    }
}
