using System;
using System.Xml.Serialization;

namespace Domain.Models
{
    [Serializable()]
    public class Order
    {
        public int Id { get; set; }

        [XmlElement("oxid")]
        public long OxId { get; set; }

        [XmlElement("orderdate")]
        public DateTime OrderDate { get; set; }

        [XmlElement("billingaddress", typeof(BillingAddress))]
        public BillingAddress BillingAddress { get; set; }

        [XmlArray("payments")]
        [XmlArrayItem("payment", typeof(Payment))]
        public Payment[] Payments { get; set; }

        [XmlArray("articles")]
        [XmlArrayItem("orderarticle", typeof(OrderArticle))]
        public OrderArticle[] Articles { get; set; }

        public string Status { get; set; }

        public int InvoiceNumber { get; set; }
    }
}
