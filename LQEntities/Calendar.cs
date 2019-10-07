using INOM.Support;
using System;
using System.Globalization;

namespace INOM.Entities
{
    public class Calendar
    {
        /// <summary>
        /// Setup Date.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Setup FundID.
        /// </summary>
        public int FundID { get; set; }
        /// <summary>
        /// Setup Add Days to Date.
        /// </summary>
        public int AddDays { get; set; }
        /// <summary>
        /// Setup if Only Labor Days are Searched.
        /// </summary>
        public bool OnlyLaborDays { get; set; }

        public Calendar()
        {
            OnlyLaborDays = true;
            AddDays = 0;
        }
        /// <summary>
        /// Validate Method 
        /// </summary>
        public static bool Validate(Calendar item, out string sCod, out string sMessage)
        {
            sMessage = "";
            sCod = "";
            bool result = true;
            result = VerifyWeekendDate(item.Date);
            if (result)
            {
                string producType = "UnitizedFund";

                // Get Instrument from CalypsoInstrument
                CalypsoInstrument calypsoInstrument = CalypsoInstrument.GetCalypsoInstrument(item.FundID);

                if (calypsoInstrument == null)
                {
                    sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0023.ToString());
                    sCod = EnumErrorCode.OMS0023.ToString();
                }
                else
                {
                    // Get Market from CalypsoCalendar
                    CalypsoCalendar calypsoCalendar = CalypsoCalendar.GetMarket(calypsoInstrument.Denominacion);

                    if (calypsoCalendar == null)
                    {
                        sMessage = LogError.ReadErrorDescription(EnumErrorCode.OMS0034.ToString());
                        sCod = EnumErrorCode.OMS0034.ToString();
                        throw new Exception(sMessage);
                    }
                    else
                    {
                        // Verify if it's holiday
                        result = CalypsoCalendar.VerifyDate(calypsoInstrument, calypsoCalendar, item, producType);                    
                    }
                }            
            }
            if (!result)
            {
                sMessage = String.Format(LogError.ReadErrorDescription(EnumErrorCode.OMS0004.ToString()), item.Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture));
                sCod = EnumErrorCode.OMS0004.ToString();
            }
            return result;
        }

        /// <summary>
        /// Returns the labor
        /// </summary>
        /// <param name="item"></param>
        /// <param name="Shift">0 to check current date and to return next labor date in case of holiday.
        /// +n or -n labor days.
        /// </param>
        /// <returns>Labor date</returns>
        public static DateTime? GetLaborDate(int iFundID, DateTime date, int Shift)
        {
            DateTime? dtReturn = null;
            string sErrorCode = null;
            string sErrorMessage = null;
            int DaysCounter = 0;       
            Calendar oCalendarVerifyDate = new Calendar();
            oCalendarVerifyDate.FundID = iFundID;
            oCalendarVerifyDate.Date = date;
            oCalendarVerifyDate.AddDays = Shift;

            do
            {
                if (Calendar.Validate(oCalendarVerifyDate, out sErrorCode, out sErrorMessage) == true)
                {
                    if (Shift == DaysCounter) {
                        dtReturn = oCalendarVerifyDate.Date;
                        continue;
                    }
                    if (Shift > 0)
                    {
                        oCalendarVerifyDate.Date = oCalendarVerifyDate.Date.AddDays(1);
                        DaysCounter++;
                    }
                    else if (Shift < 0)
                    {
                        oCalendarVerifyDate.Date = oCalendarVerifyDate.Date.AddDays(-1);
                        DaysCounter--;
                    }
                }
                else
                {
                    if (Shift >= 0)
                    {
                        oCalendarVerifyDate.Date = oCalendarVerifyDate.Date.AddDays(1);
                    }
                    else if (Shift < 0)
                    {
                        oCalendarVerifyDate.Date = oCalendarVerifyDate.Date.AddDays(-1);
                    }
                }
            } while (dtReturn == null);

            return (dtReturn);
        }

        public static bool VerifyWeekendDate(DateTime date)
        {
            bool verify = true;

            if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
            {
                verify = false;
            }
            return verify;
        }
    }
}
