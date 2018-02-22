using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;

namespace SmartHouse.Controllers
{
    public class HomeController : Controller
    {
        #region Temperature & Humidity
        public ActionResult TemperatureHumidity()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime).Take(10);
            return View(temperatureHumidityList);
        }

        public JsonResult GetTemperatureHumidityHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime);
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

            return null;
        }
        #endregion
    }
}