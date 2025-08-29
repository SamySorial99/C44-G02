using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G02_AdvC_01
{
    internal class FixedSizeList<T>
    {
        List<T> values;
        int maxSize;

        public FixedSizeList(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be greater than zero");
            }
            maxSize = size;
            values = new List<T>(size);
        }


        public void Add(T value)
        {
            if (values.Count >= maxSize)
            {
                throw new InvalidOperationException("List is full");
            }
            values.Add(value);
        }

        public T GetElement(int index) {
            return values[index];
        }
    }
}
