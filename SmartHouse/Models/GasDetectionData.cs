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

    public partial class GasDetectionData
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        public System.DateTime InternalTime { get; set; }

        [Display(Name = "Email alert sent")]
        public bool EmailAlertSent { get; set; }
    }
}
