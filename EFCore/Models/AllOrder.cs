using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EFCore.Models
{
    [Serializable()]
    [XmlRoot("orders")]
    public class AllOrder
    {
        [XmlElement("order", typeof(Order))]
        public List<Order> Orders { get; set; }
    }
}
