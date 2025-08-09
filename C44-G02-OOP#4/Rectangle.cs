using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G02_OOP_4
{
    internal class Rectangle
    {
        public int Length { get; set; }
        public int Width { get; set; }
        Rectangle()
        {
            Length = 0;
            Width = 0;
        }
        Rectangle(int length, int width)
        {
            Length = length;
            Width = width;
        }
        Rectangle(int length)
        {
            Length = length;
            Width = length; // Square
        }


    }
}
