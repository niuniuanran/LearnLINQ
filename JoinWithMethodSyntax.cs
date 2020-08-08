using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearnLinq
{
    class JoinWithMethodSyntax
    {
        static void Main(string[] args)
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
            
        }



    }
}
