﻿using System;
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

            var rdm = new Random();
            var randomNumbers = Enumerable.Range(1, 10).Select(_ => rdm.Next(1, 100));
            Console.WriteLine(string.Join(" ", randomNumbers));

            var alphabet = Enumerable.Range(0, 26).Select(c => (char)(c + 'a'));
            Console.WriteLine(string.Join(" ", alphabet));

        }
    }
}
