using NerdStore.Models.Enums;
using System;

namespace NerdStore.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public SalesStatus Status { get; set; }

        public SalesRecord(int id, DateTime date, double total, SalesStatus status)
        {
            Id = id;
            Date = date;
            Total = total;
            Status = status;
        }

        public SalesRecord()
        {
        }


        /*Vendedor responsável pela venda*/
        public Seller Seller { get; set; }
    }
}
