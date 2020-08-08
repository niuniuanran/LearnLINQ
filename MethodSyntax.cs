using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearnLinq
{
    class MethodSyntax
    {
        static void Main(string[] args)
        {
            
            List<Warrior> warriors = new List<Warrior>()
            {
                new Warrior() { Height = 100 },
                new Warrior() { Height = 80 },
                new Warrior() { Height = 100 },
                new Warrior() { Height = 70 },
            };

            var shortWarriors = warriors.Where(w => w.Height < 100)
                                        .ToList();

            shortWarriors.ForEach(w => Console.WriteLine(w.Height));


            List<Person> people = new List<Person>()
            {
                new Person("Tod", "Vachev", 1, 180, 26, Gender.Male),
                new Person("John", "Johnson", 2, 170, 21, Gender.Male),
                new Person("Anna", "Maria", 3, 150, 21, Gender.Female),
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

            SeparatingLine("GroupBy Method");

            var genderGrouping = people.GroupBy(p => p.Gender);

            var genderGrouping2 = from p in people
                                  group p by p.Gender;

            foreach (var group in genderGrouping)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group)
                {
                    Console.WriteLine($"{p.FirstName} {p.Age}");
                }
            }

            SeparatingLine("Exactly the same...");

            foreach(var group in genderGrouping2)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group)
                {
                    Console.WriteLine($"{p.FirstName} {p.Age}");
                }
            }

            SeparatingLine("Order items, group, order group");

            var orderedAgeGrouping = people.OrderBy(p=>p.FirstName).GroupBy(p => p.Age).OrderBy(g => g.Key);

            foreach (var group in orderedAgeGrouping)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group)
                {
                    Console.WriteLine($"{p.FirstName} {p.Age}");
                }
            }


            SeparatingLine("Group by composite key");

            var groupByCompositeKey = people.OrderBy(p => p.FirstName).GroupBy(p => new { p.Age, p.Gender}).OrderBy(group => group.Key.Age);

            foreach (var group in groupByCompositeKey)
            {
                Console.WriteLine(group.Key);
                foreach (var p in group)
                {
                    Console.WriteLine($"{p.FirstName} {p.Age}");
                }
            }


            SeparatingLine("Age group");

            var ageGroup = people.OrderBy(p => p.FirstName).GroupBy(p => p.Age > 35 ? "Senior" : (p.Age < 21 ? "Young" : "Adult")).OrderBy(group=> group.Key.Equals("Young")? 0: group.Key.Equals("Senior")? 2: 1);

            foreach (var group in ageGroup)
            {
                Console.WriteLine("---"+group.Key+ "---");
                foreach (var p in group)
                {
                    Console.WriteLine($"{p.FirstName} {p.Age}");
                }
            }

        }

        private static void SeparatingLine(string exp)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(exp);
        }
    }

    internal class Warrior
    {
        public int Height { get; set; }
    }
}
