using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse.Models
{
    public partial class FilterTemperatureHumidityClass
    {
        public float? TemperatureMinValue { get; set; }
        public float? TemperatureMaxValue { get; set; }
        public float? HumidityMinValue { get; set; }
        public float? HumidityMaxValue { get; set; }
        public DateTime? DateMinValue { get; set; }
        public DateTime? DateMaxValue { get; set; }
        public bool EmailAlertSent { get; set; }
    }
}