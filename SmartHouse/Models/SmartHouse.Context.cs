﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SmartHouseEntities : DbContext
    {
        public SmartHouseEntities()
            : base("name=SmartHouseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MotionDetectionData> MotionDetectionDatas { get; set; }
        public DbSet<SoundDetectionData> SoundDetectionDatas { get; set; }
        public DbSet<TemperatureHumidityData> TemperatureHumidityDatas { get; set; }
        public DbSet<TemperatureHumidityCriticalData> TemperatureHumidityCriticalDatas { get; set; }
        public DbSet<DictionaryTime> DictionaryTime { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<AirConditioningSettings> AirConditioningSettings { get; set; }
    }
}
