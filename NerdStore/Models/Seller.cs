using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="E-mail")]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        //Lista de vendas
        public ICollection<SalesRecord> Sales = new List<SalesRecord>();

        public Seller(int id, string name, string email, DateTime birthDate, double salary)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Salary = salary;
        }

        public Seller()
        {
        }

        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }
        
        public void RemoveSales(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }
    }
}
