using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FilterConvertOrder
{
    class FilterConvert
    {
        static void MyMain(string[] args)
        {

            SeparatingLine("OfType filter");
            object[] mix = { 1, 'r', 2, 3, "dog", "cat", 'a', 'c' };

            var charsInMix = mix.OfType<char>();

            Console.WriteLine(String.Join("", charsInMix));

            List<Person> people = new List<Person>()
            {
                new Buyer() { Age = 20 , ID = 1, Height = 125, Weight = 77},
                new Buyer() { Age = 25 , ID = 2, Height = 150, Weight = 88},
                new Buyer() { Age = 20 , ID = 5, Height = 100, Weight = 58},
                new Supplier() { Age = 22 },
                new Supplier() { Age = 20 }
            };

            SeparatingLine("Use query syntax to filter type");

            var buyers = from p in people
                         where p is Buyer
                         select p;
            foreach (var item in buyers)
                Console.WriteLine(item.GetType().ToString());


            SeparatingLine("Use query syntax to filter and convert type");

            var youngBuyers = from p in people
                              where p is Buyer
                              let b = p as Buyer
                              where b.Age < 25
                              select b;
            foreach (var item in youngBuyers)
                Console.WriteLine($"Buyer {item.ID} aged {item.Age} ");


            SeparatingLine("Method Syntax with filter by type and casting");

            var youngBuyerMethodSyntax = people.OfType<Buyer>().Where(b => b.Age < 25);
            foreach (var item in youngBuyerMethodSyntax)
            {
                Console.WriteLine($"Buyer {item.ID} aged {item.Age}");
            }

            SeparatingLine("Convert resulting collection to Array or List");

            var peopleArray = (from p in people
                               select p).ToList().ToArray();


            SeparatingLine("Convert type of item with Method Syntax");

            var buyersToSuppliers = people.OfType<Buyer>().ToList().ConvertAll(b => new Supplier { Age = b.Age });

            SeparatingLine("Convert type of item with Query Syntax");

            var buyersToSuppliersQuery = from p in people
                                         where p is Buyer
                                         let b = p as Buyer
                                         select new Supplier
                                         {
                                             Age = b.Age
                                         };

            SeparatingLine("Order by two criterias");
           

        }

        private static void SeparatingLine(string exp)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(exp);
        }

    }

    internal class Person
    {

    }

    internal class Buyer : Person
    {
        public int Age { get; set; }
        public int ID { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    internal class Supplier : Person
    {
        public int Age { get; set; }
    }
}
