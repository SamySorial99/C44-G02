using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G02_OOP_4
{

    public class Duration
        {
        public int Hours { get; private set; }
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }

        private static int ToTotalSeconds(int h, int m, int s) => checked(h * 3600 + m * 60 + s);
        private int TotalSeconds => ToTotalSeconds(Hours, Minutes, Seconds);

        private void SetFromTotalSeconds(int totalSeconds)
        {
            if (totalSeconds < 0) totalSeconds = 0;            // clamp at 0
            Hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            Minutes = totalSeconds / 60;
            Seconds = totalSeconds % 60;
        }
        // Constructor: Hours, Minutes, Seconds
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        // Constructor: total seconds
        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            totalSeconds %= 3600;
            Minutes = totalSeconds / 60;
            Seconds = totalSeconds % 60;
        }

        // Override ToString
        public override string ToString()
        {
            string result = "";
            if (Hours > 0)
                result += $"Hours: {Hours}, ";
            if (Minutes > 0 || Hours > 0)
                result += $"Minutes :{Minutes}, ";
            result += $"Seconds :{Seconds}";
            return result;
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj is Duration other)
            {
                return Hours == other.Hours &&
                       Minutes == other.Minutes &&
                       Seconds == other.Seconds;
            }
            return false;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }


        public static bool operator ==(Duration a, Duration b)
        => ReferenceEquals(a, b) || (!ReferenceEquals(a, null) && !ReferenceEquals(b, null) && a.TotalSeconds == b.TotalSeconds);

        public static bool operator !=(Duration a, Duration b) => !(a == b);

        // Comparison operators (by total seconds)
        public static bool operator >(Duration a, Duration b) => a.TotalSeconds > b.TotalSeconds;
        public static bool operator <(Duration a, Duration b) => a.TotalSeconds < b.TotalSeconds;
        public static bool operator >=(Duration a, Duration b) => a.TotalSeconds >= b.TotalSeconds;
        public static bool operator <=(Duration a, Duration b) => a.TotalSeconds <= b.TotalSeconds;

        // Addition
        public static Duration operator +(Duration a, Duration b)
            => new Duration(a.TotalSeconds + b.TotalSeconds);

        public static Duration operator +(Duration a, int seconds)
            => new Duration(a.TotalSeconds + seconds);

        public static Duration operator +(int seconds, Duration a)
            => new Duration(a.TotalSeconds + seconds);

        // Subtraction
        public static Duration operator -(Duration a, Duration b)
            => new Duration(a.TotalSeconds - b.TotalSeconds);    // clamped to 0 inside ctor

        public static Duration operator -(Duration a, int seconds)
            => new Duration(a.TotalSeconds - seconds);

        // ++ / -- (increase/decrease ONE MINUTE)
        // Mutate the instance (so ++D1 updates D1) and return it.
        public static Duration operator ++(Duration a)
        {
            a.SetFromTotalSeconds(a.TotalSeconds + 60);
            return a;
        }

        public static Duration operator --(Duration a)
        {
            a.SetFromTotalSeconds(a.TotalSeconds - 60);
            return a;
        }

        // Allow usage in: if (D1)  -> true when duration > 0
        public static bool operator true(Duration a) => a is not null && a.TotalSeconds > 0;
        public static bool operator false(Duration a) => !(a is not null && a.TotalSeconds > 0);

        // Explicit cast to DateTime: base = today at 00:00, add duration
        public static explicit operator DateTime(Duration d)
            => DateTime.Today.AddSeconds(d.TotalSeconds);
    }
}

