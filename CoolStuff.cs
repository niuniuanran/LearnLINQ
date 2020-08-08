using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace LearnLinq
{
    class CoolStuff
    {
        static void Main(string[] args)
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

            SeparatingLine("Set Operation - Distinct");

            string catSentence = "I am a cat!";
            catSentence.Distinct().ToList().ForEach(c => Console.WriteLine(c));

            SeparatingLine("Set Operation - Intersect");

            string dogSentence = "I am a dog!";
            catSentence.Intersect(dogSentence).ToList().ForEach(c => Console.WriteLine(c));

            SeparatingLine("Set Operation - Union");

            catSentence.Union(dogSentence).ToList().ForEach(c => Console.WriteLine(c));

            SeparatingLine("Set Operation - Except");
            catSentence.Except(dogSentence).ToList().ForEach(c => Console.WriteLine(c));


            SeparatingLine("Quantifying Operations Start here!");

            SeparatingLine("Quantifying Operation - All");

            Console.WriteLine(numbers.All(n => n < 10));

            SeparatingLine("Quantifying Operation - Any");

            Console.WriteLine(numbers.Any(n => n > 10));

            Console.WriteLine(string.Empty.Any()); // Check if there is any element in the collection

            SeparatingLine("Quantifying Operation - Contains");

            Console.WriteLine(numbers.Contains(3));



            SeparatingLine("Partitioning Operations Start here!");

            int[] ints = { 1, 2, 3, 3, 4, 5, 6, 7, 7, 7, 9, 9, 10 };

            SeparatingLine("Partitioning Operation - Skip");

            ints.Skip(1).ToList().ForEach(n => Console.WriteLine(n));

            SeparatingLine("Partitioning Operation - Take");

            ints.Take(3).ToList().ForEach(n => Console.WriteLine(n));

            SeparatingLine("Partitioning Operation - SkipWhile");

            ints.SkipWhile(n => n < 5).ToList().ForEach(n => Console.WriteLine(n));

            SeparatingLine("Partitioning Operation - TakeWhile");

            ints.TakeWhile(n => n < 5).ToList().ForEach(n => Console.WriteLine(n));

        }


        private static void SeparatingLine(string exp)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(exp);
        }
    }
}
