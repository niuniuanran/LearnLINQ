﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearnLinq
{
    class JoinQueries
    {
        static void Main (String[] args)
        {
            List<Buyer> buyers = new List<Buyer>()
            {
                new Buyer() { Name = "Johny", District = "Fantasy District", Age = 22},
                new Buyer() { Name = "Peter", District = "Scientists District", Age = 40},
                new Buyer() { Name = "Paul", District = "Fantasy District", Age = 30 },
                new Buyer() { Name = "Maria", District = "Scientists District", Age = 35 },
                new Buyer() { Name = "Joshua", District = "Scientists District", Age = 40 },
                new Buyer() { Name = "Sylvia", District = "Developers District", Age = 22 },
                new Buyer() { Name = "Rebecca", District = "Scientists District", Age = 30 },
                new Buyer() { Name = "Jaime", District = "Developers District", Age = 35 },
                new Buyer() { Name = "Pierce", District = "Fantasy District", Age = 40 }
            };
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "Harrison", District = "Fantasy District", Age = 22 },
                new Supplier() { Name = "Charles", District = "Developers District", Age = 40 },
                new Supplier() { Name = "Hailee", District = "Scientists District", Age = 35 },
                new Supplier() { Name = "Taylor", District = "EarthIsFlat District", Age = 30 }
            };


            SeparatingLine("Join buyers and suppliers by their district");

            var innerJoin = from s in suppliers
                            join b in buyers on s.District equals b.District
                            select new
                            {
                                SupplierName = s.Name,
                                BuyerName = b.Name,
                                b.District
                            };

            foreach (var districtMath in innerJoin)
            {
                Console.WriteLine($"{districtMath}");
            }


        }

        private static void SeparatingLine(string explaination)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(explaination);
        }
    }

    internal class Supplier
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }

    internal class Buyer
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int Age { get; set; }
    }
}
