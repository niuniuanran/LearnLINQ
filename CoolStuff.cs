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

            int[] ints = { 1, 2, 3, 3, 7, 4, 5, 6, 7, 7, 7, 9, 9, 10 };

            SeparatingLine("Partitioning Operation - Skip");
            ints.Skip(1).ToList().ForEach(n => Console.WriteLine(n));

            SeparatingLine("Partitioning Operation - Take");
            ints.Take(3).ToList().ForEach(n => Console.WriteLine(n));

            SeparatingLine("Partitioning Operation - SkipWhile");
            ints.SkipWhile(n => n < 5).ToList().ForEach(n => Console.WriteLine(n));

            SeparatingLine("Partitioning Operation - TakeWhile");
            ints.TakeWhile(n => n < 5).ToList().ForEach(n => Console.WriteLine(n));

            SeparatingLine("Partitioning Operation - OrderByDescending then TakeWhile");
            ints.OrderByDescending(n=>n).TakeWhile(n=> n>5).ToList().ForEach(n => Console.WriteLine(n));



            SeparatingLine("Concat method Start here!");
            ints.Concat(numbers).ToList().ForEach(n => Console.WriteLine(n));

            SeparatingLine("Powerful Concat");
            ints.Take(ints.Length / 2)
                .Concat(ints.Skip(ints.Length / 2).Select(n=>n*n))
                .ToList().ForEach(n => Console.WriteLine(n));


            int[] integers = { 1, 2, 3, 4,5};

            SeparatingLine("Aggeragation Operations Start here!");

            SeparatingLine("Aggeragation Operation - Aggregate");
            int sum = integers.Aggregate((acc, i)=>acc+i);
            Console.WriteLine($"Sum: {sum}");

            SeparatingLine("Aggeragation Operation - Aggregate, with a Seed");
            int productTriple = integers.Aggregate(3, (acc, i) => acc * i);
            Console.WriteLine($"product: {productTriple}");

            SeparatingLine("Aggeragation Operation - Sum, Average, Min, Max");
            int sumEasy = integers.Sum();
            Console.WriteLine($"Sum: {sum}");
            double average = integers.Average();
            Console.WriteLine($"Ave: {average}");
            int min = integers.Min();
            Console.WriteLine($"Min: {min}");

            SeparatingLine("More things to do with Aggregation");
            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 22, Gender.Female),
                new Person("Kyle", "Wilson", 4, 164, 29, Gender.Male),
                new Person("Anna", "Williams", 5, 164, 28, Gender.Male),
                new Person("Maria", "Ann", 6, 160, 43, Gender.Female),
                new Person("John", "Jones", 7, 160, 37, Gender.Female),
                new Person("Samba", "TheLion", 8, 175, 33, Gender.Male),
                new Person("Aaron", "Myers", 9, 182, 21, Gender.Male),
                new Person("Aby", "Wood", 10, 165, 20, Gender.Female),
                new Person("Maddie","Lewis",  11, 160, 19, Gender.Female),
                new Person("Lara", "Croft", 12, 162, 18, Gender.Female)
            };
            double averageAge = people.Average(p => p.Age);
            Console.WriteLine($"Average age: {averageAge}");



        }


        private static void SeparatingLine(string exp)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(exp);
        }
    }
}
