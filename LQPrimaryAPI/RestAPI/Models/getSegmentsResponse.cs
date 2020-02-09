using System;
using System.Collections.Generic;
using System.Text;

namespace LatamQuants.PrimaryAPI.Models
{
    public static class getSegmentsResponse
    {
        public class Segment
        {
            public string marketSegmentId { get; set; }
            public string marketId { get; set; }
        }

        public class RootObject
        {
            public string status { get; set; }
            public List<Segment> segments { get; set; }
        }
    }
}
