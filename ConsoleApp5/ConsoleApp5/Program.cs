using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 9;
            int c = 10;

            int max = Math.Max(Math.Max(a, b), c);

            Console.WriteLine(max);
        }
    }
}
