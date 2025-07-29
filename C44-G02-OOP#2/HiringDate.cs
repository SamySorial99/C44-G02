using System;

namespace ConsoleApp1
{
    public class HiringDate
    {
        private int Day;
        private int Month;
        private int Year;

        public DateTime Date { get; private set; }

        public HiringDate(int year, int month, int day)
        {
            // Validation
            if (year < 1900 || year > DateTime.Now.Year)
                throw new ArgumentOutOfRangeException(nameof(year), "Invalid year");
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Invalid month");
            if (day < 1 || day > DateTime.DaysInMonth(year, month))
                throw new ArgumentOutOfRangeException(nameof(day), "Invalid day");

            Year = year;
            Month = month;
            Day = day;
            Date = new DateTime(year, month, day);
        }

        public HiringDate(DateTime date)
        {
            Date = date;
            Year = date.Year;
            Month = date.Month;
            Day = date.Day;
        }

        public int GetDay() => Day;
        public int GetMonth() => Month;
        public int GetYear() => Year;

        public override string ToString()
        {
            return $"{Year:D4}-{Month:D2}-{Day:D2}";
        }
    }
}
