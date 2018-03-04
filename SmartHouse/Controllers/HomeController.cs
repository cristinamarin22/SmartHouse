using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Resources;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SmartHouse.Controllers
{
    public class HomeController : Controller
    {
        #region Delete

        #region Delete All Records
        public ActionResult DeleteAllRecordsTemperatureHumidityData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                using (var context = new SmartHouseEntities())
                {
                    var deleted = context.Database.ExecuteSqlCommand("delete from TemperatureHumidityData");
                }

                var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime);
                return Json(temperatureHumidityList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<TemperatureHumidityData>(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteAllRecordsTemperatureHumidityCriticalData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                using (var context = new SmartHouseEntities())
                {
                    var deleted = context.Database.ExecuteSqlCommand("delete from TemperatureHumidityCriticalData");
                }

                var temperatureHumidityCriticalList = smartHouseEntities.TemperatureHumidityCriticalDatas.ToList().OrderByDescending(x => x.InternalTime);
                return Json(temperatureHumidityCriticalList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<TemperatureHumidityCriticalData>(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteAllRecordsMotionDetectionData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                using (var context = new SmartHouseEntities())
                {
                    var deleted = context.Database.ExecuteSqlCommand("delete from MotionDetectionData");
                }

                var motionDetectionList = smartHouseEntities.MotionDetectionDatas.ToList().OrderByDescending(x => x.InternalTime);
                return Json(motionDetectionList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<MotionDetectionData>(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteAllRecordsSoundDetectionData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                using (var context = new SmartHouseEntities())
                {
                    var deleted = context.Database.ExecuteSqlCommand("delete from SoundDetectionData");
                }

                var soundDetectionList = smartHouseEntities.SoundDetectionDatas.ToList().OrderByDescending(x => x.InternalTime);
                return Json(soundDetectionList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<SoundDetectionData>(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete One Record
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

        public ActionResult DeleteMotionDetectionData(int? id)
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

        public ActionResult DeleteSoundDetectionData(int? id)
        {
            if (id == null)
            {
                return null;
            }

            SmartHouseEntities smartHouse = new SmartHouseEntities();
            SoundDetectionData soundDetection = smartHouse.SoundDetectionDatas.Find(id);
            if (soundDetection == null)
            {
                return HttpNotFound();
            }
            smartHouse.SoundDetectionDatas.Remove(soundDetection);
            smartHouse.SaveChanges();
            return RedirectToAction("SoundDetection");
        }
        #endregion

        #region Delete Filtered Records
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
        
        public JsonResult DeleteFilteredTemperatureHumidityCriticalData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            var temperatureHumidityCriticalDataList = smartHouseEntities.TemperatureHumidityCriticalDatas.ToList();

            if (filter.TemperatureMinValue != null)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.Temperature >= filter.TemperatureMinValue).ToList();

            if (filter.TemperatureMaxValue != null)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.Temperature <= filter.TemperatureMaxValue).ToList();

            if (filter.HumidityMinValue != null)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.Humidity >= filter.HumidityMinValue).ToList();

            if (filter.HumidityMaxValue != null)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.Humidity <= filter.HumidityMaxValue).ToList();

            if (filter.DateMinValue != null)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.InternalTime >= filter.DateMinValue).ToList();

            if (filter.DateMaxValue != null)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.InternalTime <= filter.DateMaxValue).ToList();

            foreach (var filteredItem in temperatureHumidityCriticalDataList)
            {
                TemperatureHumidityCriticalData temperatureHumidityCriticalData = smartHouseEntities.TemperatureHumidityCriticalDatas.Find(filteredItem.Id);
                smartHouseEntities.TemperatureHumidityCriticalDatas.Remove(temperatureHumidityCriticalData);
            }

            smartHouseEntities.SaveChanges();

            return Json(new List<TemperatureHumidityCriticalData>(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteFilteredMotionDetectionData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            var motionDetectionList = smartHouseEntities.MotionDetectionDatas.ToList();

            if (filter.DateMinValue != null)
                motionDetectionList = motionDetectionList.Where(x => x.InternalTime >= filter.DateMinValue).ToList();

            if (filter.DateMaxValue != null)
                motionDetectionList = motionDetectionList.Where(x => x.InternalTime <= filter.DateMaxValue).ToList();

            foreach (var filteredItem in motionDetectionList)
            {
                MotionDetectionData motionDetectionData = smartHouseEntities.MotionDetectionDatas.Find(filteredItem.Id);
                smartHouseEntities.MotionDetectionDatas.Remove(motionDetectionData);
            }

            smartHouseEntities.SaveChanges();

            return Json(new List<MotionDetectionData>(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteFilteredSoundDetectionData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            var soundDetectionList = smartHouseEntities.SoundDetectionDatas.ToList();

            if (filter.DateMinValue != null)
                soundDetectionList = soundDetectionList.Where(x => x.InternalTime >= filter.DateMinValue).ToList();

            if (filter.DateMaxValue != null)
                soundDetectionList = soundDetectionList.Where(x => x.InternalTime <= filter.DateMaxValue).ToList();

            foreach (var filteredItem in soundDetectionList)
            {
                SoundDetectionData soundDetectionData = smartHouseEntities.SoundDetectionDatas.Find(filteredItem.Id);
                smartHouseEntities.SoundDetectionDatas.Remove(soundDetectionData);
            }

            smartHouseEntities.SaveChanges();

            return Json(new List<SoundDetectionData>(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        #region Views

        #region Temperature & Humidity
        public ActionResult TemperatureHumidity()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return View(smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime));
            else
                return View(new List<TemperatureHumidityData>());
        }

        public JsonResult GetTemperatureHumidityHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return Json(smartHouseEntities.TemperatureHumidityDatas.ToList().OrderByDescending(x => x.InternalTime), JsonRequestBehavior.AllowGet);
            else
                return Json(new List<TemperatureHumidityData>(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Temperature & Humidity Critical Data
        public JsonResult GetTemperatureHumidityCriticalHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return Json(smartHouseEntities.TemperatureHumidityCriticalDatas.ToList().OrderByDescending(x => x.InternalTime), JsonRequestBehavior.AllowGet);
            else
                return Json(new List<TemperatureHumidityCriticalData>(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult TemperatureHumidityCriticalData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return View(smartHouseEntities.TemperatureHumidityCriticalDatas.ToList().OrderByDescending(x => x.InternalTime));
            else
                return View(new List<TemperatureHumidityCriticalData>());
        }
        #endregion

        #region Motion Detection
        public ActionResult MotionDetection()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return View(smartHouseEntities.MotionDetectionDatas.ToList().OrderByDescending(x => x.InternalTime));
            else
                return View(new List<MotionDetectionData>());
        }

        public JsonResult GetMotionDetectionHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return Json(smartHouseEntities.MotionDetectionDatas.ToList().OrderByDescending(x => x.InternalTime), JsonRequestBehavior.AllowGet);
            else
                return Json(new List<MotionDetectionData>(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sound Detection
        public ActionResult SoundDetection()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return View(smartHouseEntities.SoundDetectionDatas.ToList().OrderByDescending(x => x.InternalTime).Take(10));
            else
                return View(new List<SoundDetectionData>());
        }

        public JsonResult GetSoundDetectionHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return Json(smartHouseEntities.SoundDetectionDatas.ToList().OrderByDescending(x => x.InternalTime));
            else
                return Json(new List<SoundDetectionData>(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Setting
        public ActionResult Setting()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return View(smartHouseEntities.Settings.FirstOrDefault());
            else
                return View(new List<Settings>());
        }

        [HttpPost]
        public JsonResult SaveSettings(Settings settings)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                #region Temperature & Humidity
                smartHouseEntities.Settings.FirstOrDefault().CriticalTemperatureAlertYN = settings.CriticalTemperatureAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().CriticalTemperatureAlertValue = settings.CriticalTemperatureAlertValue;
                smartHouseEntities.Settings.FirstOrDefault().CriticalHumidityAlertYN = settings.CriticalHumidityAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().CriticalHumidityAlertValue = settings.CriticalHumidityAlertValue;
                smartHouseEntities.Settings.FirstOrDefault().DeleteTemperatureHumidityHistoricalDataOlderThan = settings.DeleteTemperatureHumidityHistoricalDataOlderThan;
                smartHouseEntities.Settings.FirstOrDefault().DeleteTemperatureHumidityHistoricalDataOlderThanUnitMeasure = settings.DeleteTemperatureHumidityHistoricalDataOlderThanUnitMeasure;
                #endregion

                #region Motion Detection
                smartHouseEntities.Settings.FirstOrDefault().MotionDetectionAlertYN = settings.MotionDetectionAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().SendMotionDetectionEmailAlertInterval = settings.SendMotionDetectionEmailAlertInterval;
                smartHouseEntities.Settings.FirstOrDefault().SendMotionDetectionEmailAlertIntervalUnitMeasure = settings.SendMotionDetectionEmailAlertIntervalUnitMeasure;
                smartHouseEntities.Settings.FirstOrDefault().DeleteMotionDetectionHistoricalDataOlderThan = settings.DeleteMotionDetectionHistoricalDataOlderThan;
                smartHouseEntities.Settings.FirstOrDefault().DeleteMotionDetectionHistoricalDataOlderThanUnitMeasure = settings.DeleteMotionDetectionHistoricalDataOlderThanUnitMeasure;
                #endregion

                #region Sound Detection
                smartHouseEntities.Settings.FirstOrDefault().SoundDetectionAlertYN = settings.SoundDetectionAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().DeleteSoundDetectionHistoricalDataOlderThan = settings.DeleteSoundDetectionHistoricalDataOlderThan;
                smartHouseEntities.Settings.FirstOrDefault().DeleteSoundDetectionHistoricalDataOlderThanUnitMeasure = settings.DeleteSoundDetectionHistoricalDataOlderThanUnitMeasure;
                #endregion

                #region Gas Detection
                smartHouseEntities.Settings.FirstOrDefault().CriticalGasAlertYN = settings.CriticalGasAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().CriticalGasHistoricalDataOlderThan = settings.CriticalGasHistoricalDataOlderThan;
                smartHouseEntities.Settings.FirstOrDefault().CriticalGasHistoricalDataOlderThanUnitMeasure = settings.CriticalGasHistoricalDataOlderThanUnitMeasure;
                #endregion

                #region General
                smartHouseEntities.Settings.FirstOrDefault().AlertsToEmail = settings.AlertsToEmail;
                smartHouseEntities.Settings.FirstOrDefault().InternalTime = DateTime.Now;
                #endregion

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
            }

            return Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        #region Filter Data
        public JsonResult FilterTemperatureHumidityData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            if (smartHouseEntities.Database.Exists())
            {
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
            else
                return Json(new List<TemperatureHumidityData>(), JsonRequestBehavior.AllowGet);

        }

        public JsonResult FilterTemperatureHumidityCriticalData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            if (smartHouseEntities.Database.Exists())
            {
                var temperatureHumidityCriticalDataList = smartHouseEntities.TemperatureHumidityCriticalDatas.ToList();

                if (filter.TemperatureMinValue != null)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.Temperature >= filter.TemperatureMinValue).ToList();

                if (filter.TemperatureMaxValue != null)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.Temperature <= filter.TemperatureMaxValue).ToList();

                if (filter.HumidityMinValue != null)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.Humidity >= filter.HumidityMinValue).ToList();

                if (filter.HumidityMaxValue != null)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.Humidity <= filter.HumidityMaxValue).ToList();

                if (filter.DateMinValue != null)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.InternalTime >= filter.DateMinValue).ToList();

                if (filter.DateMaxValue != null)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.InternalTime <= filter.DateMaxValue).ToList();

                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.OrderByDescending(x => x.InternalTime).ToList();

                return Json(temperatureHumidityCriticalDataList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<TemperatureHumidityCriticalData>(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FilterMotionDetectionData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            if (smartHouseEntities.Database.Exists())
            {
                var motionDetectionList = smartHouseEntities.MotionDetectionDatas.ToList();

                if (filter.DateMinValue != null)
                    motionDetectionList = motionDetectionList.Where(x => x.InternalTime >= filter.DateMinValue).ToList();

                if (filter.DateMaxValue != null)
                    motionDetectionList = motionDetectionList.Where(x => x.InternalTime <= filter.DateMaxValue).ToList();

                motionDetectionList = motionDetectionList.OrderByDescending(x => x.InternalTime).ToList();

                return Json(motionDetectionList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<MotionDetectionData>(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FilterSoundDetectionData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            if (smartHouseEntities.Database.Exists())
            {
                var soundDetectionList = smartHouseEntities.SoundDetectionDatas.ToList();

                if (filter.DateMinValue != null)
                    soundDetectionList = soundDetectionList.Where(x => x.InternalTime >= filter.DateMinValue).ToList();

                if (filter.DateMaxValue != null)
                    soundDetectionList = soundDetectionList.Where(x => x.InternalTime <= filter.DateMaxValue).ToList();

                soundDetectionList = soundDetectionList.OrderByDescending(x => x.InternalTime).ToList();

                return Json(soundDetectionList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<SoundDetectionData>(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        public void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("cristinamarin2201@gmail.com");
                mail.To.Add("cristinamarin2201@gmail.com");
                mail.Subject = "Smart House Alert";
                mail.Body = "This is a temperature alert";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("cristinamarin2201", Constants.psswd);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}