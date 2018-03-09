//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TemperatureHumidityCriticalData
    {
        public int Id { get; set; }
        public System.DateTime InternalTime { get; set; }
        [Display(Name = "Temperature")]
        public float Temperature { get; set; }

        [Display(Name = "Humidity")]
        public float Humidity { get; set; }
        public int TemperatureHumidityDataId { get; set; }

        [Display(Name = "Critical temperature")]
        public int CriticalTemperature { get; set; }

        [Display(Name = "Critical humidity")]
        public int CriticalHumidity { get; set; }

        [Display(Name = "Email alert sent")]
        public bool EmailAlertSent { get; set; }

        [Display(Name = "Min critical temperature")]
        public Nullable<decimal> MinCriticalTemperature { get; set; }

        [Display(Name = "Max critical temperature")]
        public Nullable<decimal> MaxCriticalTemperature { get; set; }

        [Display(Name = "Min critical humidity")]
        public Nullable<decimal> MinCriticalHumidity { get; set; }

        [Display(Name = "Max critical humidity")]
        public Nullable<decimal> MaxCriticalHumidity { get; set; }
    }
}
