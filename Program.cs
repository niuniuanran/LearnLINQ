﻿using System;
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

            foreach(var group in genderGroup)
            {
                Console.WriteLine($"--- { group.Key} Group ---");
                foreach (var p in group)
                {
                    Console.WriteLine($"{p.FirstName} {p.Gender}");
                }
            }

            var ageGroup = from p in people
                           group p by (p.Age > 25);
            foreach (var group in ageGroup)
            {
                Console.WriteLine($"-- People {(group.Key ? "above":"under")} 25 years old --- ");
                foreach (var p in group)
                    Console.WriteLine($"{p.FirstName} {p.Age}");

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
