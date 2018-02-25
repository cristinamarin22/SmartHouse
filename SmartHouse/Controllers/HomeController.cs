﻿using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Web;
using System.Web.Mvc;

namespace SmartHouse.Controllers
{
    public class HomeController : Controller
    {
        #region Delete
        public ActionResult DeleteMotionDetection(int? id)
        {
            if (id == null)
            {
                return null;
            }

            SmartHouseEntities smartHouse = new SmartHouseEntities();
            MotionDetectionData motionDetection = smartHouse.MotionDetectionDatas.Find(id);
            if (motionDetection == null)
            {
                return HttpNotFound();
            }
            smartHouse.MotionDetectionDatas.Remove(motionDetection);
            smartHouse.SaveChanges();
            return RedirectToAction("MotionDetection");
        }


        public ActionResult DeleteTemperatureHumidityData(int? id)
        { 
            if (id == null)
            {
                return null;
            }

            SmartHouseEntities smartHouse = new SmartHouseEntities();
            TemperatureHumidityData temperatureHumidityData = smartHouse.TemperatureHumidityDatas.Find(id);
            if (temperatureHumidityData == null)
            {
                return HttpNotFound();
            }
            smartHouse.TemperatureHumidityDatas.Remove(temperatureHumidityData);
            smartHouse.SaveChanges();
            return RedirectToAction("TemperatureHumidity");
        }

        public ActionResult DeleteTemperatureHumidityCriticalData(int? id)
        {
            if (id == null)
            {
                return null;
            }

            SmartHouseEntities smartHouse = new SmartHouseEntities();
            TemperatureHumidityCriticalData temperatureHumidityCriticalData = smartHouse.TemperatureHumidityCriticalDatas.Find(id);
            if (temperatureHumidityCriticalData == null)
            {
                return HttpNotFound();
            }
            smartHouse.TemperatureHumidityCriticalDatas.Remove(temperatureHumidityCriticalData);
            smartHouse.SaveChanges();
            return RedirectToAction("TemperatureHumidityCriticalData");
        }

        public ActionResult DeleteAllRecordsTemperatureHumidityData()
        {
            using (var context = new SmartHouseEntities())
            {
                var deleted = context.Database.ExecuteSqlCommand("delete from TemperatureHumidityData");
            }

            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime);
            return Json(temperatureHumidityList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteFilteredTemperatureHumidityData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList();

            if (filter.TemperatureMinValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.Temperature >= filter.TemperatureMinValue).ToList();

            if (filter.TemperatureMaxValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.Temperature <= filter.TemperatureMaxValue).ToList();

            if (filter.HumidityMinValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.Humidity >= filter.HumidityMinValue).ToList();

            if (filter.HumidityMaxValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.Humidity <= filter.HumidityMaxValue).ToList();

            if (filter.DateMinValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.InternalTime >= filter.DateMinValue).ToList();

            if (filter.DateMaxValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.InternalTime <= filter.DateMaxValue).ToList();

            foreach (var filteredItem in temperatureHumidityList)
            {
                TemperatureHumidityData temperatureHumidityData = smartHouseEntities.TemperatureHumidityDatas.Find(filteredItem.Id);
                smartHouseEntities.TemperatureHumidityDatas.Remove(temperatureHumidityData);
            }

            smartHouseEntities.SaveChanges();

            return Json(new List<TemperatureHumidityData>() , JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Temperature & Humidity
        public ActionResult TemperatureHumidity()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            //var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime).Take(10);
            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime);
            return View(temperatureHumidityList);
        }

        public JsonResult GetTemperatureHumidityHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime);
            return Json(temperatureHumidityList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Temperature & Humidity
        public ActionResult TemperatureHumidityCriticalData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityCriticalDatas.ToList().OrderByDescending(x => x.InternalTime);
            return View(temperatureHumidityList);
        }
        #endregion

        #region FilterTemperatureHumidityData
        public JsonResult FilterTemperatureHumidityData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            
            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList();

            if (filter.TemperatureMinValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.Temperature >= filter.TemperatureMinValue).ToList();

            if (filter.TemperatureMaxValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.Temperature <= filter.TemperatureMaxValue).ToList();

            if (filter.HumidityMinValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.Humidity >= filter.HumidityMinValue).ToList();

            if (filter.HumidityMaxValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.Humidity <= filter.HumidityMaxValue).ToList();

            if (filter.DateMinValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.InternalTime >= filter.DateMinValue).ToList();

            if (filter.DateMaxValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.InternalTime <= filter.DateMaxValue).ToList();

            temperatureHumidityList = temperatureHumidityList.OrderByDescending(x => x.InternalTime).ToList();

            return Json(temperatureHumidityList, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Motion Detection
        public ActionResult MotionDetection()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var motionDetectionList = smartHouseEntities.MotionDetectionDatas.ToList().OrderByDescending(x => x.InternalTime).Take(10);
            return View(motionDetectionList);
        }

        public JsonResult GetMotionDetectionHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var motionDetectionList = smartHouseEntities.MotionDetectionDatas.ToList().OrderByDescending(x => x.InternalTime);
            return Json(motionDetectionList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sound Detection
        public ActionResult SoundDetection()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var soundDetectionList = smartHouseEntities.SoundDetectionDatas.ToList().OrderByDescending(x => x.InternalTime).Take(10);
            return View(soundDetectionList);
        }

        public JsonResult GetSoundDetectionHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var soundDetectionList = smartHouseEntities.SoundDetectionDatas.ToList().OrderByDescending(x => x.InternalTime);
            return Json(soundDetectionList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Setting
        public ActionResult Setting()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            Settings settings = smartHouseEntities.Settings.FirstOrDefault();

            //var allTime = Dictionary.TimeDictionary;
            //var items = new List<SelectListItem>();

            //foreach (var time in allTime)
            //{
            //    items.Add(new SelectListItem()
            //    {
            //        Value = time.Id.ToString(),
            //        Text = time.Name,
                   
            //        // Put all sorts of business logic in here
            //        Selected = time.Id == smartHouseEntities.Settings.FirstOrDefault().DeleteTemperatureHumidityHistoricalDataOlderThanUnitMeasure ? true : false
            //    });
            //}

            //model.Countries = items;



            return View(settings);
        }
        #endregion

        #region SaveSettings
        [HttpPost]
        public JsonResult SaveSettings(Settings settings)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            smartHouseEntities.Settings.FirstOrDefault().CriticalTemperatureAlertYN = settings.CriticalTemperatureAlertYN;
            smartHouseEntities.Settings.FirstOrDefault().CriticalTemperatureAlertValue = settings.CriticalTemperatureAlertValue;
            smartHouseEntities.Settings.FirstOrDefault().CriticalHumidityAlertYN = settings.CriticalHumidityAlertYN;
            smartHouseEntities.Settings.FirstOrDefault().CriticalHumidityAlertValue = settings.CriticalHumidityAlertValue;
            smartHouseEntities.Settings.FirstOrDefault().DeleteTemperatureHumidityHistoricalDataOlderThan = settings.DeleteTemperatureHumidityHistoricalDataOlderThan;
            smartHouseEntities.Settings.FirstOrDefault().DeleteTemperatureHumidityHistoricalDataOlderThanUnitMeasure = settings.DeleteTemperatureHumidityHistoricalDataOlderThanUnitMeasure;
            smartHouseEntities.Settings.FirstOrDefault().MotionDetectionAlertYN = settings.MotionDetectionAlertYN;
            smartHouseEntities.Settings.FirstOrDefault().DeleteMotionDetectionHistoricalDataOlderThan = settings.DeleteMotionDetectionHistoricalDataOlderThan;
            smartHouseEntities.Settings.FirstOrDefault().DeleteMotionDetectionHistoricalDataOlderThanUnitMeasure = settings.DeleteMotionDetectionHistoricalDataOlderThanUnitMeasure;
            smartHouseEntities.Settings.FirstOrDefault().SoundDetectionAlertYN = settings.SoundDetectionAlertYN;
            smartHouseEntities.Settings.FirstOrDefault().DeleteSoundDetectionHistoricalDataOlderThan = settings.DeleteSoundDetectionHistoricalDataOlderThan;
            smartHouseEntities.Settings.FirstOrDefault().DeleteSoundDetectionHistoricalDataOlderThanUnitMeasure = settings.DeleteSoundDetectionHistoricalDataOlderThanUnitMeasure;
            smartHouseEntities.Settings.FirstOrDefault().CriticalGasAlertYN = settings.CriticalGasAlertYN;
            smartHouseEntities.Settings.FirstOrDefault().CriticalGasHistoricalDataOlderThan = settings.CriticalGasHistoricalDataOlderThan;
            smartHouseEntities.Settings.FirstOrDefault().CriticalGasHistoricalDataOlderThanUnitMeasure = settings.CriticalGasHistoricalDataOlderThanUnitMeasure;
            smartHouseEntities.Settings.FirstOrDefault().AlertsToEmail = settings.AlertsToEmail;
            smartHouseEntities.Settings.FirstOrDefault().InternalTime = DateTime.Now;
            smartHouseEntities.SaveChanges();

            #region DeleteHistoryData
            using (var context = new SmartHouseEntities())
            {
                #region Temperature & Humidity
                var a = context.Database.ExecuteSqlCommand(String.Format(Resources.Strings.jobDeleteTemperatureHumidityHistoryData, Constants.DictionaryTime.FirstOrDefault(x => x.Key == settings.DeleteTemperatureHumidityHistoricalDataOlderThanUnitMeasure).Value, settings.DeleteTemperatureHumidityHistoricalDataOlderThan));
                #endregion

                #region Motion Detection
                a = context.Database.ExecuteSqlCommand(String.Format(Resources.Strings.jobDeleteMotionDetectionHistoryData, Constants.DictionaryTime.FirstOrDefault(x => x.Key == settings.DeleteMotionDetectionHistoricalDataOlderThanUnitMeasure).Value, settings.DeleteMotionDetectionHistoricalDataOlderThan));
                #endregion

                #region Sound Detection
                a = context.Database.ExecuteSqlCommand(String.Format(Resources.Strings.jobDeleteSoundDetectionHistoryData, Constants.DictionaryTime.FirstOrDefault(x => x.Key == settings.DeleteSoundDetectionHistoricalDataOlderThanUnitMeasure).Value, settings.DeleteSoundDetectionHistoricalDataOlderThan));
                #endregion
            }
            #endregion

            RedirectToAction("Setting");

            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}