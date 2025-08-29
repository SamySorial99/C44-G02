using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G02_AdvC_01
{
    internal class Range<T> where T : IComparable<T>
    {
        T MinRange { get; set; }
        T MaxRange { get; set; }

        public Range(T minRange, T maxRange)
        {
            if (minRange.CompareTo(maxRange) > 0)
            {
                throw new ArgumentException("MinRange cannot be greater than MaxRange");
            }
            MinRange = minRange;
            MaxRange = maxRange;
        }

        public bool IsInRange(T value)
        {
            return value.CompareTo(MinRange) >= 0 && value.CompareTo(MaxRange) <= 0;
        }

        public T Length()
        {
            dynamic min = MinRange;
            dynamic max = MaxRange;
            return max - min;
        }

        public override string ToString()
        {
            return $"[{MinRange}, {MaxRange}]";
        }

    }
}
