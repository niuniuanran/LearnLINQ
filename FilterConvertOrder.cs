using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearnLinq
{
    class FilterConvertOrder
    {
        static void Main(string[] args)
        {

            SeparatingLine("OfType filter");
            object[] mix = { 1, 'r', 2, 3, "dog", "cat", 'a', 'c' };

            var charsInMix = mix.OfType<char>();

            Console.WriteLine(String.Join("", charsInMix));
        }

        private static void SeparatingLine(string exp)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(exp);
        }

    }
}
