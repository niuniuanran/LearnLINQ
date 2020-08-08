using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace LearnLinq
{
    class CoolStuff
    {
        static void Main (string[] args)
        {
            var manyAs = Enumerable.Repeat("A", 30);
            Console.WriteLine(string.Join("", manyAs));


            var numbers = Enumerable.Range(3, 10);
            Console.WriteLine(string.Join(" ", numbers));


            var evenNumbers = Enumerable.Range(1, 10).Where(n => n % 2 == 0);
            Console.WriteLine(string.Join(" ", evenNumbers));



        }
    }
}
