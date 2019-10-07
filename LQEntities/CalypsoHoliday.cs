using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class CalypsoHoliday
    {
        /// <summary>
        /// Id Calypso Funds.
        /// </summary>
        [Key]
        public int CalypsoHolidayID { get; set; }

        /// <summary>
        /// Id Calendario.
        /// </summary>
        public string CalendarID { get; set; }

        /// <summary>
        /// HolidayDate date and time.
        /// </summary>
        public DateTime HolidayDate { get; set; }

        /// <summary>
        /// Save.
        /// </summary>
        public static void Save(CalypsoHoliday calypsoHolidays)
        {
            using (var db = new DBContext())
            {
                db.CalypsoHolidays.Add(calypsoHolidays);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Update.
        /// </summary>
        public static void Update(CalypsoHoliday calypsoHolidays)
        {
            using (var db = new DBContext())
            {
                db.CalypsoHolidays.Attach(calypsoHolidays);
                db.Entry(calypsoHolidays).State = EntityState.Modified;
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
                var allRec = db.CalypsoHolidays;
                db.CalypsoHolidays.RemoveRange(allRec);
                db.SaveChanges();
            }
        }

    }
}
