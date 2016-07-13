using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Common.Helpers
{
    /// <summary>
    /// Persian Date Converter
    /// 
    /// </summary>
    public static class PersianDate
    {
        private const char RightToLeftEmbedding = '\x202B';
        private const char PopDirectionalFormatting = '\x202C';

        /// <summary>
        /// If you see dd/mm/yyy instead of yyyy/mm/dd in your RTL reports, use this method to fix it.
        /// 
        /// </summary>
        /// <param name="data">string data</param>
        /// <returns>
        /// A fixed string
        /// </returns>
        public static string FixWeakCharacters2(this string data)
        {
            if (string.IsNullOrEmpty(data))
                return string.Empty;
            var strArray = new string[8]
      {
        "\\",
        "/",
        "+",
        "-",
        "=",
        ";",
        "$",
        ":"
      };
            foreach (string oldValue in strArray)
                data = data.Replace(oldValue, (string)(object)'\x202B' + (object)oldValue + (string)(object)'\x202C');
            return data;
        }

        /// <summary>
        /// Converts Gregorian date to Shamsi/Persian date
        /// 
        /// </summary>
        /// <param name="gregorianDate">Gregorian date</param><param name="dateSeparator">Defines an optional separator between date's parts. Its default value is /</param><param name="includeHourMinute">Should converter include hour and minutes in final result. Its default value is true</param><param name="showLeftAlignedHourMinute">If includeHourMinute is true, indicates whether to show hh:mm yyyy/mm/dd or yyyy/mm/dd hh:mm</param><param name="timeSeparator">Defines an optional separator between time's parts. Its default value is :</param>
        /// <returns>
        /// Persian/Shamsi DateTime string
        /// </returns>
        public static string ToPersianDateTime2(this DateTime gregorianDate, string dateSeparator = "/", bool includeHourMinute = true, bool showLeftAlignedHourMinute = true, string timeSeparator = ":")
        {
            if (gregorianDate == DateTime.MinValue) return "";
            int year1 = gregorianDate.Year;
            int month1 = gregorianDate.Month;
            int day = gregorianDate.Day;
            var persianCalendar = new PersianCalendar();
            int year2 = persianCalendar.GetYear(new DateTime(year1, month1, day, (Calendar)new GregorianCalendar()));
            int month2 = persianCalendar.GetMonth(new DateTime(year1, month1, day, (Calendar)new GregorianCalendar()));
            int dayOfMonth = persianCalendar.GetDayOfMonth(new DateTime(year1, month1, day, (Calendar)new GregorianCalendar()));
            if (!includeHourMinute)
                return string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}{1}{2}{1}{3}", (object)year2, (object)dateSeparator, (object)month2.ToString("00", (IFormatProvider)CultureInfo.InvariantCulture), (object)dayOfMonth.ToString("00", (IFormatProvider)CultureInfo.InvariantCulture));
            else if (!showLeftAlignedHourMinute)
                return string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{2}{3}{4}{3}{5}  {0}{6}{1}", (object)gregorianDate.Hour, (object)gregorianDate.Minute, (object)year2, (object)dateSeparator, (object)month2.ToString("00", (IFormatProvider)CultureInfo.InvariantCulture), (object)dayOfMonth.ToString("00", (IFormatProvider)CultureInfo.InvariantCulture), (object)timeSeparator);
            else
                return string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}{6}{1}  {2}{3}{4}{3}{5}", (object)gregorianDate.Hour, (object)gregorianDate.Minute, (object)year2, (object)dateSeparator, (object)month2.ToString("00", (IFormatProvider)CultureInfo.InvariantCulture), (object)dayOfMonth.ToString("00", (IFormatProvider)CultureInfo.InvariantCulture), (object)timeSeparator);
        }

        public static DateTime ToGregorianDate2(string persianDateTime)
        {
            if (string.IsNullOrEmpty(persianDateTime)) return DateTime.MinValue;
            var pcal = new PersianCalendar();
            var persianDateSplit = persianDateTime.Split('/');
            var gregorianDate = pcal.ToDateTime(Convert.ToInt32(persianDateSplit[0]), Convert.ToInt32(persianDateSplit[1]), Convert.ToInt32(persianDateSplit[2]), 0, 0, 0, 0);
            return gregorianDate;
        }


    }
}
