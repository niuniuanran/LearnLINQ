using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearnLinq
{
    class JoinWithMethodSyntax
    {
        static void MyMain(string[] args)
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


            var innerJoin = suppliers.Join(buyers, s => s.District, b => b.District, (s, b) => new { District = s.District, SupplierName = s.Name, BuyerName = b.Name, });
            foreach (var match in innerJoin)
            {
                Console.WriteLine($"{match.District}: Supplier {match.SupplierName}, Buyer {match.BuyerName}");
            }

            SeparatingLine("Composite Inner Join");

            var compositeInnerJoin = suppliers.Join(buyers, s => new { s.District, s.Age }, b => new { b.District, b.Age }, (s, b) => new { s.District, s.Age, SupplierName = s.Name, BuyerName = b.Name, });
            foreach (var match in compositeInnerJoin)
            {
                Console.WriteLine($"{match.District}, Aged {match.Age}: Supplier {match.SupplierName}, Buyer {match.BuyerName}");
            }

            SeparatingLine("Group Join");

            var groupJoinByDistrict = suppliers
                .GroupJoin(buyers,
                s => s.District,
                b => b.District,
                (s, buyerGroup) => new
                {
                    s.Name,
                    s.District,
                    Buyers = buyerGroup
                });

            foreach (var supplier in groupJoinByDistrict)
            {
                Console.WriteLine($"Supplier: {supplier.Name} in {supplier.District}");
                foreach (var buyer in supplier.Buyers)
                    Console.WriteLine($"   Buyer: {buyer.Name}");
            }

            SeparatingLine("Left Outer join - Flattened with Anonymous type");

            var outerJoinByDistrict = suppliers.GroupJoin(buyers, s => s.District, b => b.District, (s, g) => new { s.Name, s.District, Buyers = g })
                .SelectMany(s => s.Buyers.DefaultIfEmpty(), (s, b) => new { s.Name, s.District, BuyerName = b?.Name ?? "No One"}); 
            // SelectMany takes a collection selector, which is a function used to extract a collection from the original collection's item, 
            // and a result selector, which is a function taking the original item and the items in the extracted collection and then generating a new result.
            // SelectMany flattens nested collection (result of GroupJoin or Grouping) into a new collection.

            foreach (var match in outerJoinByDistrict)
            {
                Console.WriteLine($"{match.District}, Supplier {match.Name}, Buyer {match.BuyerName}");
            }

            SeparatingLine("Left Outer join, grouped and type specific");

            var outerJoinWithBuyerType = suppliers.GroupJoin(buyers, s => s.District, b => b.District, (s, g) => new { s.Name, s.District, Buyers = g.DefaultIfEmpty(new Buyer { Name = "No One" }) });
            foreach (var supplier in outerJoinWithBuyerType)
            {
                Console.WriteLine($"Supplier: {supplier.Name} in {supplier.District}");
                foreach (var buyer in supplier.Buyers)
                    Console.WriteLine($"   Buyer: {buyer.Name}");
            }

            SeparatingLine("Left Outer join, flattened and type specific");

            var outerJoinFlattendBuyerType = suppliers.GroupJoin(buyers, s => s.District, b => b.District, (s, g) => new { s.Name, s.District, Buyers = g.DefaultIfEmpty(new Buyer { Name = "No one", District = "No where" }) })
                .SelectMany(s => s.Buyers, (s, b) => new { Supplier = s, Buyer = b });

            foreach (var match in outerJoinFlattendBuyerType)
            {
                Console.WriteLine($"{match.Supplier.District}, Supplier {match.Supplier.Name}");
                Console.WriteLine($"   Buyer: {match.Buyer.Name} in {match.Buyer.District}");
            }


        }

        private static void SeparatingLine(string exp)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(exp);
        }





    }
}
