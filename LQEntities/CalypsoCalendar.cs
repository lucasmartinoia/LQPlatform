using INOM.Support;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace INOM.Entities
{
    public class CalypsoCalendar : IEquatable<CalypsoCalendar>
    {
        /// <summary>
        /// Id Calypso Calendar.
        /// </summary>
        [Key]
        public int CalypsoCalendarID { get; set; }

        /// <summary>
        /// Tipo de Producto.
        /// </summary>
        [StringLength(50)]
        public string ProductType { get; set; }

        /// <summary>
        /// Instrumento.
        /// </summary>
        public string Instrument { get; set; }

        /// <summary>
        /// Mercado.
        /// </summary>
        public string Market { get; set; }

        /// <summary>
        /// Id Calendario.
        /// </summary>
        public string CalendarID { get; set; }

        /// <summary>
        /// Save.
        /// </summary>
        public static void Save(CalypsoCalendar calypsoCalendars)
        {
            using (var db = new DBContext())
            {
                db.CalypsoCalendars.Add(calypsoCalendars);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update.
        /// </summary>
        public static void Update(CalypsoCalendar calypsoCalendars)
        {
            using (var db = new DBContext())
            {
                db.CalypsoCalendars.Attach(calypsoCalendars);
                db.Entry(calypsoCalendars).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// DeleteAll.
        /// </summary>
        public static void DeleteAll()
        {
            using (var db = new DBContext())
            {
                var allRec = db.CalypsoCalendars;
                db.CalypsoCalendars.RemoveRange(allRec);
                db.SaveChanges();
            }
        }

        public bool Equals(CalypsoCalendar other)
        {

            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return CalendarID.Equals(other.CalendarID);
        }

        public override int GetHashCode()
        {
            //Get hash code for the Code field. 
            int hashCalendarCode = CalendarID.GetHashCode();

            //Calculate the hash code for the product. 
            return hashCalendarCode;
        }

        public static bool VerifyDate(CalypsoInstrument calypsoInstrument, CalypsoCalendar calypsoCalendar, Calendar item, string productType)
        {

            // Get CalendarID from CalypsoCalendar
            var res = GetCalendarID(calypsoInstrument.Denominacion, productType, calypsoCalendar.Market, item.FundID);

            // Verify if it's holiday
            return VerifyCalendarHoliday(res.CalendarID, item.Date);
        }

        public static bool VerifyCalendarHoliday(string id, DateTime date)
        {
            bool availableDay;

            using (var db = new DBContext())
            {
                int res = db.CalypsoHolidays.Count(a => a.CalendarID == id && a.HolidayDate.Date == date.Date);

                if (res > 0)
                    availableDay = false;
                else
                    availableDay = true;

                return availableDay;
            }
        }

        public static CalypsoCalendar GetCalendarID(string instrument, string producType, string market, int fundID)
        {

            if (market == " " || String.IsNullOrEmpty(market))
                // Get CalendarID without using Market as a parameter
                return GetCalendarID(instrument, producType);
            else
                //Get CalendarID using Market as a parameter
                return GetCalendarID(instrument, producType, market);
        }

        public static CalypsoCalendar GetCalendarID(string Instrument, string ProducType)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var res = db.CalypsoCalendars.Where(a => a.Instrument == Instrument && a.ProductType == ProducType).FirstOrDefault();
                    return res;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Save(0, Assembly.GetEntryAssembly().GetName().Name, LogError.ReadErrorDescription(EnumErrorCode.OMS9999.ToString()), EnumErrorCode.OMS9999, ex, "", 0, 0);
                //Console.WriteLine(ex);
            }
            return null;
        }

        public static CalypsoCalendar GetCalendarID(string Instrument, string ProducType, string Market)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var res = db.CalypsoCalendars.Where(a => a.Instrument == Instrument && a.ProductType == ProducType && a.Market == Market).FirstOrDefault();
                    return res;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Save(0, Assembly.GetEntryAssembly().GetName().Name, LogError.ReadErrorDescription(EnumErrorCode.OMS9999.ToString()), EnumErrorCode.OMS9999, ex, "", 0, 0);
                // Console.WriteLine(ex);
            }
            return null;
        }

        public static CalypsoCalendar GetMarket(string denominacion)
        {
            try
            {
                using (var db = new DBContext())
                {
                    var res = db.CalypsoCalendars.Where(a => a.Instrument == denominacion).FirstOrDefault();
                    return res;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Save(0, Assembly.GetEntryAssembly().GetName().Name, LogError.ReadErrorDescription(EnumErrorCode.OMS9999.ToString()), EnumErrorCode.OMS9999, ex, "", 0, 0);
                // Console.WriteLine("{0} Exception caught.", ex);
            }
            return null;
        }

    }
}

