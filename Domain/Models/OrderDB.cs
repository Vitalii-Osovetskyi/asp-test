using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class OrderDB
    {
        public int Id { get; set; }

        public long OxId { get; set; }

        public DateTime OrderDate { get; set; }

        public BillingAddress BillingAddress { get; set; }

        public List<Payment> Payments { get; set; }

        public List<OrderArticle> Articles { get; set; }

        public string Status { get; set; }

        public int InvoiceNumber { get; set; }
    }
}
