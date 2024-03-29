﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SmartHouse.Models
{
    [DataContract]
    public class DataPoint
    {
        public DataPoint(DateTime x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public DataPoint(string x, double y)
        {
            this.XMonth = x;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<DateTime> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "xMonth")]
        public string XMonth = String.Empty;
    }
}