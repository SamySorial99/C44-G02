using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G02_OOP_4
{
    internal class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public ComplexNumber()
        {
            Real = 0;
            Imaginary = 0;
        }
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public ComplexNumber(double real)
        {
            Real = real;
            Imaginary = 0; // Pure real number
        }


        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }
}
