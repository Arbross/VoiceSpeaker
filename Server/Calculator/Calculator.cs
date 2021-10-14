using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Calculator
    {
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Share(double a, double b)
        {
            return a / b;
        }
        public static double Plus(double a, double b)
        {
            return a + b;
        }
        public static double Minus(double a, double b)
        {
            return a - b;
        }
        public static double Sqrt(double a, double b)
        {
            return Math.Sqrt(a);
        }
        public static double Pow(double a, double b)
        {
            return Math.Pow(a, b); 
        }
    }
}
