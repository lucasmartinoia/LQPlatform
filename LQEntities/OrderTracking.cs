using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace INOM.Entities
{
    public class OrderTracking
    {

        /// <summary>
        /// Order Tracking ID.
        /// </summary>
        [Key]
        public int OrderTrackingID { get; set; }
        
        /// <summary>
        /// Order Identifier.
        /// </summary>
        [Required]
        public int OrderID { get; set; }

        /// <summary>
        /// Order.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Market Order Identifier.
        /// </summary>
        public int MarketOrderID { get; set; }

        /// <summary>
        /// Market Trade Identifier.
        /// </summary>
        public int MarketTradeID { get; set; }

        /// <summary>
        /// Event description.
        /// </summary>
        [StringLength(200)]
        public string Event { get; set; }

        /// <summary>
        /// Event description.
        /// </summary>
        [StringLength(200)]
        public string EventInfo { get; set; }

        /// <summary>
        /// Component name.
        /// </summary>
        [StringLength(200)]
        public string Component { get; set; }

        /// <summary>
        /// Record creation date and time.
        /// </summary>
        public DateTime When { get; set; }

        //public static void TrackOrder(string Component, string Event, int OrderID, int MarketOrderID = 0, int MarketTradeID = 0)
        //{
        //    OrderTracking oTracking = new OrderTracking();

        //    oTracking.Component = Component;
        //    oTracking.Event = Event;
        //    oTracking.OrderID = OrderID;
        //    oTracking.MarketOrderID = MarketOrderID;
        //    oTracking.MarketTradeID = MarketTradeID;

        //    using (var db = new DBContext())
        //    {
        //        db.OrdersTracking.Add(oTracking);
        //        db.SaveChanges();
        //    }
        //}
        public static void Save(OrderTracking oTracking)
        {
            using (var db = new DBContext())
            {
                db.OrdersTracking.Add(oTracking);
                db.SaveChanges();
            }
        }

        public static void SaveTracking(int Orderid, int MarketOrderID, int MarketTradeID = 0, string status = "", [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            OrderTracking orderTracking = new OrderTracking()
            {
                When = DateTime.Now,
                Component = Assembly.GetCallingAssembly().GetName().Name, // Assembly.GetEntryAssembly().GetName().Name,
                Event = memberName,
                OrderID = Orderid,
                MarketOrderID = MarketOrderID,
                EventInfo = status,
                MarketTradeID = MarketTradeID
            };
            Save(orderTracking);
        }
    }
}
