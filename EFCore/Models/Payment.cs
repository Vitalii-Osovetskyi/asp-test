﻿using System;
using System.Xml.Serialization;

namespace EFCore.Models
{
    [Serializable()]
    public class Payment
    {
        public int Id { get; set; }

        [XmlElement("method-name")]
        public string MethodName { get; set; }

        [XmlElement("amount")]
        public double Amount { get; set; }
    }
}
