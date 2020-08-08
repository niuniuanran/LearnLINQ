using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnLinq
{
    class Order
    {
        static void MyMain (string[] args)
        {
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

            people.OrderBy(p => p.Gender).ThenBy(p => p.ID).ToList().ForEach(p => Console.WriteLine($"{p.FirstName}\t{p.ID} {p.Gender}"));

            people.OrderBy(p => p.Gender).ThenByDescending(p => p.ID).ToList().ForEach(p => Console.WriteLine($"{p.FirstName}\t{p.ID} {p.Gender}"));

        }
    }
}
