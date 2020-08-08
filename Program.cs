using System;
using System.Collections.Generic;
using System.Linq;
namespace LearnLinq
{
    class LearnLinq
    {
        private static void SeparatingLine()
        {
            Console.WriteLine(new string('=', 40));
        }

        static void Main(string[] args)
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

            var youngPeople = from p in people
                              where p.Age < 25
                              let fullName = $"{p.FirstName} {p.LastName}"
                              select (new YoungPerson { Age = p.Age, FullName = fullName });

            Console.WriteLine(youngPeople);

            foreach (var p in youngPeople)
            {
                Console.WriteLine($"I am a young people. My name is {p.FullName} and I am {p.Age} years old.");
            }

            SeparatingLine();
            Console.WriteLine("Practicing Grouping");


            var genderGroup = from p in people
                              where p.FirstName.StartsWith("A")
                              group p by p.Gender; // a linq query can end with either a group call or a select call. So here we don't need a select.

            Console.WriteLine(genderGroup);

            foreach (var group in genderGroup)
            {
                Console.WriteLine($"--- { group.Key} Group ---");
                foreach (var p in group)
                {
                    Console.WriteLine($"{p.FirstName} {p.Gender}");
                }
            }

            SeparatingLine();
            Console.WriteLine("Group into 25+ and 25- ");

            var ageGroup = from p in people
                           group p by (p.Age > 25);
            foreach (var group in ageGroup)
            {
                Console.WriteLine($"-- People {(group.Key ? "above" : "under")} 25 years old --- ");
                foreach (var p in group)
                    Console.WriteLine($"{p.FirstName} {p.Age}");

            }

            SeparatingLine();
            Console.WriteLine("Group by multiple keys");

            var multipleKeys = from p in people
                               group p by new { p.Gender, p.Age };
            foreach (var key in multipleKeys)
            {
                Console.WriteLine($"--{key.Key}--");
                foreach (var p in key.OrderBy(p => p.Age))
                {
                    Console.WriteLine($"{p.FirstName} {p.Gender} {p.Age}");
                }
            }

            SeparatingLine();
            Console.WriteLine("1: Group then Order groups, will be rewritten by into keyword");

            var orderedKeys = from key in (from p in people group p by p.FirstName[0])
                              orderby key.Count()
                              select key;
            foreach (var key in orderedKeys)
            {
                Console.WriteLine($"--Name starting with {key.Key} -- {key.Count()} people in the group--");
                foreach (var p in key.OrderBy(p => p.Age))
                {
                    Console.WriteLine($"{p.FirstName} {p.Gender} {p.Age}");
                }
            }


            SeparatingLine();
            Console.WriteLine("Redo alphabetic grouping in 1 with into keyword");

            var newOrderedByCountKeys = from p in people
                                        group p by p.FirstName[0] into groupByFirstLetter
                                        orderby groupByFirstLetter.Key
                                        select groupByFirstLetter;

            foreach (var key in orderedKeys)
            {
                Console.WriteLine($"--Name starting with {key.Key} -- {key.Count()} people in the group--");
                foreach (var p in key)
                {
                    Console.WriteLine($"{p.FirstName} {p.Gender} {p.Age}");
                }
            }


            SeparatingLine();
            Console.WriteLine("Group people into three age groups");

            var threeAgeGroupingKeys = from p in people
                                       orderby p.Age
                                       let ageGroupName = ((p.Age > 40)
                                                             ? "senior"
                                                             : p.Age < 25
                                                                   ? "young"
                                                                   : "middle")
                                       group p by ageGroupName into grouped
                                       select grouped;
            foreach (var key in threeAgeGroupingKeys)
            {
                Console.WriteLine($"--Age Group {key.Key} -- {key.Count()} people in the age group--");
                foreach (var p in key)
                {
                    Console.WriteLine($"{p.FirstName} {p.Gender} {p.Age}");
                }
            }


            SeparatingLine();
            Console.WriteLine("Summarize group member number");

            var howManyPeopleInEachGroup = from p in people
                                           group p by p.Gender into g
                                           select new { Gender = g.Key, GroupSize = g.Count() };
            foreach (var groupSum in howManyPeopleInEachGroup)
            {
                Console.WriteLine(groupSum);
            }



        }
    }




    internal class YoungPerson
    {
        public string FullName { get; set; }
        public int Age { get; set; }
    }

    internal class Person
    {
        private string firstName;
        private string lastName;
        private int id;
        private int height;
        private int age;

        private Gender gender;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        public Person(string firstName, string lastName, int id, int height, int age, Gender gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.Height = height;
            this.Age = age;
            this.Gender = gender;
        }
    }

    internal enum Gender
    {
        Male,
        Female
    }

}
