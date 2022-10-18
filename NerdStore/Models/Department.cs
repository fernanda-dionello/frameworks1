using System.Collections.Generic;

namespace NerdStore.Models
{
    public class Department
    {
        //ctrl + fn + d
        public int Id { get; set; }
        public string Name { get; set; }

        //interface de coleção, representa qualquer tipo de lista
        public ICollection<Seller> Sellers = new List<Seller>();


        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Department()
        {
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }
    }
}
