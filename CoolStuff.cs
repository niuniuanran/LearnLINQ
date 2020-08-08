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

            var rdm = new Random();
            var randomNumbers = Enumerable.Range(1, 10).Select(_ => rdm.Next(1, 100));
            Console.WriteLine(string.Join(" ", randomNumbers));

            var alphabet = Enumerable.Range(0, 26).Select(c => (char)(c + 'a'));
            Console.WriteLine(string.Join(" ", alphabet));


            SeparatingLine("Check collections for equality");

            string[] catnames = { "Lucy", "Loki" };
            string[] catnames2 = { "Lucy", "Loki" };
            Console.WriteLine(catnames.SequenceEqual(catnames2));



            SeparatingLine("Set Operations Start here!");

            SeparatingLine("Distinct Set Operation");

            string catSentence = "I am a cat!";
            catSentence.Distinct().ToList().ForEach(c=>Console.WriteLine(c));



        }


        private static void SeparatingLine(string exp)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(exp);
        }
    }
}
