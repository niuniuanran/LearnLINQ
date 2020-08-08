using System;
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


            SeparatingLine("Inner Join buyers and suppliers by their district");

            var innerJoin = from s in suppliers
                            orderby s.District
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

            SeparatingLine("Inner Join by composite keys district and age");

            var compositeJoin = from s in suppliers
                                join b in buyers on new { s.District, s.Age } equals new { b.District, b.Age }
                                select new
                                {
                                    SupplierName = s.Name,
                                    BuyerName = b.Name,
                                    b.District,
                                    b.Age
                                };
            foreach (var districtAgeMatch in compositeJoin)
            {
                Console.WriteLine($"{districtAgeMatch}");
            }


            SeparatingLine("Group Join, give each supplier a collection of its buyers."); 

            var groupJoin = from s in suppliers
                            join b in buyers on s.District equals b.District into buyerGroup
                            select new
                            {
                                s.Name,
                                s.District,
                                Buyers = from b in buyerGroup
                                         orderby b.Age
                                         select b
                            };

            foreach (var supplierWithBuyerGroup in groupJoin)
            {
                Console.WriteLine($"Supplier: {supplierWithBuyerGroup.Name} in District {supplierWithBuyerGroup.District}");
                foreach (var buyer in supplierWithBuyerGroup.Buyers)
                {
                    Console.WriteLine($"   Buyer: {buyer.Name} Age: {buyer.Age}");
                }
            }


            SeparatingLine("Left outer join. If there is an item with no match, left outer join will assign a default value to it");

            var leftOuterJoin = from s in suppliers
                                join b in buyers on s.District equals b.District into buyerGroup
                                select new
                                {
                                    s.Name,
                                    s.District,
                                    Buyers = buyerGroup.DefaultIfEmpty(new Buyer() 
                                                                            { Name = "No one",
                                                                              District = "Nowhere" })
                                };

            foreach (var supplierWithBuyerGroup in leftOuterJoin)
            {
                Console.WriteLine($"Supplier: {supplierWithBuyerGroup.Name} in District {supplierWithBuyerGroup.District}");
                foreach (var buyer in supplierWithBuyerGroup.Buyers)
                {
                    Console.WriteLine($"   Buyer: {buyer.Name} {buyer.District}");
                }
            }

            SeparatingLine("Left outer join with anonymous class");


            var leftOuterJoinWithAnonymous = from s in suppliers
                                             join b in buyers on s.District equals b.District into buyersGroup
                                              // If argument is empty, return the parameter type's default value, here is null
                                             select new
                                             {
                                                 s.Name,
                                                 s.District,
                                                 Buyers = from bG in buyersGroup.DefaultIfEmpty() 
                                                          select new { BuyerName = bG?.Name ?? "No One"}  // ?. is null-conditional operator and ?? is null-coalesce operator
                                             };
            foreach (var supplierWithBuyerGroup in leftOuterJoinWithAnonymous)
            {
                Console.WriteLine($"Supplier: {supplierWithBuyerGroup.Name} in District {supplierWithBuyerGroup.District}");
                foreach (var buyer in supplierWithBuyerGroup.Buyers)
                {
                    Console.WriteLine($"   Buyer: {buyer.BuyerName}");
                }

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
