using System;
using System.Xml.Serialization;

namespace Domain.Models
{
    [Serializable()]
    public class BillingAddress
    {
        public int Id { get; set; }

        [XmlElement("billemail")]
        public string BillEmail { get; set; }

        [XmlElement("billfname")]
        public string BillFname { get; set; }

        [XmlElement("billstreet")]
        public string BillStreet { get; set; }

        [XmlElement("billstreetnr")]
        public int BillStreetNr { get; set; }

        [XmlElement("billcity")]
        public string BillCity { get; set; }

        [XmlElement("country", typeof(Country))]
        public Country Country { get; set; }

        [XmlElement("billzip")]
        public int BillZip { get; set; }

        public int OrderDBId { get; set; }
    }
}
