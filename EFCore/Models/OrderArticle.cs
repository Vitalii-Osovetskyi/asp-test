using System;
using System.Xml.Serialization;

namespace EFCore.Models
{
    [Serializable()]
    public class OrderArticle
    {
        public int Id { get; set; }

        [XmlElement("artnum")]
        public long Artnum { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("amount")]
        public int Amount { get; set; }

        [XmlElement("brutprice")]
        public double BrutPrice { get; set; }
    }
}
