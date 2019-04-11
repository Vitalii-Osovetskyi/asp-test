using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Domain.Models
{
    [Serializable()]
    [XmlRoot("orders")]
    public class AllOrder
    {
        [XmlElement("order", typeof(Order))]
        public List<Order> Orders { get; set; }
    }
}
