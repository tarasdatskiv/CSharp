using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab1_1_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 5;
            double b = 5;
            double x = 5;

            double sign = Math.Sign(a*x+b);
            double abs = Math.Abs(x-b);
            double y = Math.Sqrt(sign - abs);

            Console.WriteLine(y);

        }
    }
}
