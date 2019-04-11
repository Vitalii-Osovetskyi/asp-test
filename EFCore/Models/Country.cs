using System;
using System.Xml.Serialization;

namespace EFCore.Models
{
    [Serializable()]
    public class Country
    {
        public int Id { get; set; }

        [XmlElement("geo")]
        public string Geo { get; set; }
    }
}
