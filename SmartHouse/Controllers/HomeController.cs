using Newtonsoft.Json;
using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.EntityClient;
using System.Diagnostics;
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

        public ActionResult DeleteAllRecordsGasDetectionData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                using (var context = new SmartHouseEntities())
                {
                    var deleted = context.Database.ExecuteSqlCommand("delete from GasDetectionData");
                }

                var gasDetectionList = smartHouseEntities.GasDetectionData.ToList().OrderByDescending(x => x.InternalTime);
                return Json(gasDetectionList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<GasDetectionData>(), JsonRequestBehavior.AllowGet);
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

        public ActionResult DeleteGasDetectionData(int? id)
        {
            if (id == null)
            {
                return null;
            }

            SmartHouseEntities smartHouse = new SmartHouseEntities();
            GasDetectionData gasDetection = smartHouse.GasDetectionData.Find(id);
            if (gasDetection == null)
            {
                return HttpNotFound();
            }
            smartHouse.GasDetectionData.Remove(gasDetection);
            smartHouse.SaveChanges();
            return RedirectToAction("GasDetection");
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
                temperatureHumidityList = temperatureHumidityList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

            if (filter.DateMaxValue != null)
                temperatureHumidityList = temperatureHumidityList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

            foreach (var filteredItem in temperatureHumidityList)
            {
                TemperatureHumidityData temperatureHumidityData = smartHouseEntities.TemperatureHumidityDatas.Find(filteredItem.Id);
                smartHouseEntities.TemperatureHumidityDatas.Remove(temperatureHumidityData);
            }

            smartHouseEntities.SaveChanges();

            return Json(new List<TemperatureHumidityData>(), JsonRequestBehavior.AllowGet);
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
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

            if (filter.DateMaxValue != null)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

            if (filter.TemperatureEmailAlertSent)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.TemperatureEmailAlertSent).ToList();

            if (filter.HumidityEmailAlertSent)
                temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.HumidityEmailAlertSent).ToList();

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
                motionDetectionList = motionDetectionList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

            if (filter.DateMaxValue != null)
                motionDetectionList = motionDetectionList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

            if (filter.TemperatureEmailAlertSent)
                motionDetectionList = motionDetectionList.Where(x => x.EmailAlertSent).ToList();

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
                soundDetectionList = soundDetectionList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

            if (filter.DateMaxValue != null)
                soundDetectionList = soundDetectionList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

            if (filter.TemperatureEmailAlertSent)
                soundDetectionList = soundDetectionList.Where(x => x.EmailAlertSent).ToList();

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

        #region Gas Detection
        public ActionResult GasDetection()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return View(smartHouseEntities.GasDetectionData.ToList().OrderByDescending(x => x.InternalTime));
            else
                return View(new List<GasDetectionData>());
        }

        public JsonResult GetGasDetectionHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return Json(smartHouseEntities.GasDetectionData.ToList().OrderByDescending(x => x.InternalTime), JsonRequestBehavior.AllowGet);
            else
                return Json(new List<GasDetectionData>(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sound Detection
        public ActionResult SoundDetection()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return View(smartHouseEntities.SoundDetectionDatas.ToList().OrderByDescending(x => x.InternalTime));
            else
                return View(new List<SoundDetectionData>());
        }

        public JsonResult GetSoundDetectionHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
                return Json(smartHouseEntities.SoundDetectionDatas.ToList().OrderByDescending(x => x.InternalTime), JsonRequestBehavior.AllowGet);
            else
                return Json(new List<SoundDetectionData>(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Setting
        public ActionResult Setting()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                return View(smartHouseEntities.Settings.FirstOrDefault());
            }
            else
            {
                return View(new Settings());
            }
        }

        [HttpPost]
        public JsonResult SaveSettings(Settings settings)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                #region Temperature & Humidity
                smartHouseEntities.Settings.FirstOrDefault().TemperatureHumidityOn = settings.TemperatureHumidityOn;
                smartHouseEntities.Settings.FirstOrDefault().CriticalTemperatureAlertYN = settings.CriticalTemperatureAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().CriticalTemperatureAlertMinValue = settings.CriticalTemperatureAlertMinValue;
                smartHouseEntities.Settings.FirstOrDefault().CriticalTemperatureAlertMaxValue = settings.CriticalTemperatureAlertMaxValue;
                smartHouseEntities.Settings.FirstOrDefault().SendTemperatureEmailAlertInterval = settings.SendTemperatureEmailAlertInterval;
                smartHouseEntities.Settings.FirstOrDefault().SendTemperatureEmailAlertIntervalUnitMeasure = settings.SendTemperatureEmailAlertIntervalUnitMeasure;
                smartHouseEntities.Settings.FirstOrDefault().CriticalHumidityAlertYN = settings.CriticalHumidityAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().CriticalHumidityAlertMinValue = settings.CriticalHumidityAlertMinValue;
                smartHouseEntities.Settings.FirstOrDefault().CriticalHumidityAlertMaxValue = settings.CriticalHumidityAlertMaxValue;
                smartHouseEntities.Settings.FirstOrDefault().SendHumidityEmailAlertInterval = settings.SendHumidityEmailAlertInterval;
                smartHouseEntities.Settings.FirstOrDefault().SendHumidityEmailAlertIntervalUnitMeasure = settings.SendHumidityEmailAlertIntervalUnitMeasure;
                smartHouseEntities.Settings.FirstOrDefault().DeleteTemperatureHumidityHistoricalDataOlderThan = settings.DeleteTemperatureHumidityHistoricalDataOlderThan;
                smartHouseEntities.Settings.FirstOrDefault().DeleteTemperatureHumidityHistoricalDataOlderThanUnitMeasure = settings.DeleteTemperatureHumidityHistoricalDataOlderThanUnitMeasure;
                #endregion

                #region Motion Detection
                smartHouseEntities.Settings.FirstOrDefault().MotionDetectionOn = settings.MotionDetectionOn;
                smartHouseEntities.Settings.FirstOrDefault().MotionDetectionAlertYN = settings.MotionDetectionAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().SendMotionDetectionEmailAlertInterval = settings.SendMotionDetectionEmailAlertInterval;
                smartHouseEntities.Settings.FirstOrDefault().SendMotionDetectionEmailAlertIntervalUnitMeasure = settings.SendMotionDetectionEmailAlertIntervalUnitMeasure;
                smartHouseEntities.Settings.FirstOrDefault().DeleteMotionDetectionHistoricalDataOlderThan = settings.DeleteMotionDetectionHistoricalDataOlderThan;
                smartHouseEntities.Settings.FirstOrDefault().DeleteMotionDetectionHistoricalDataOlderThanUnitMeasure = settings.DeleteMotionDetectionHistoricalDataOlderThanUnitMeasure;
                #endregion

                #region Sound Detection
                smartHouseEntities.Settings.FirstOrDefault().SoundDetectionOn = settings.SoundDetectionOn;
                smartHouseEntities.Settings.FirstOrDefault().SoundDetectionAlertYN = settings.SoundDetectionAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().SendSoundDetectionEmailAlertInterval = settings.SendSoundDetectionEmailAlertInterval;
                smartHouseEntities.Settings.FirstOrDefault().SendSoundDetectionEmailAlertIntervalUnitMeasure = settings.SendSoundDetectionEmailAlertIntervalUnitMeasure;
                smartHouseEntities.Settings.FirstOrDefault().DeleteSoundDetectionHistoricalDataOlderThan = settings.DeleteSoundDetectionHistoricalDataOlderThan;
                smartHouseEntities.Settings.FirstOrDefault().DeleteSoundDetectionHistoricalDataOlderThanUnitMeasure = settings.DeleteSoundDetectionHistoricalDataOlderThanUnitMeasure;
                #endregion

                #region Gas Detection
                smartHouseEntities.Settings.FirstOrDefault().GasDetectionOn = settings.GasDetectionOn;
                smartHouseEntities.Settings.FirstOrDefault().GasDetectionAlertYN = settings.GasDetectionAlertYN;
                smartHouseEntities.Settings.FirstOrDefault().SendGasDetectionEmailAlertInterval = settings.SendGasDetectionEmailAlertInterval;
                smartHouseEntities.Settings.FirstOrDefault().SendGasDetectionEmailAlertIntervalUnitMeasure = settings.SendGasDetectionEmailAlertIntervalUnitMeasure;
                smartHouseEntities.Settings.FirstOrDefault().DeleteGasDetectionHistoricalDataOlderThan = settings.DeleteGasDetectionHistoricalDataOlderThan;
                smartHouseEntities.Settings.FirstOrDefault().DeleteGasDetectionHistoricalDataOlderThanUnitMeasure = settings.DeleteGasDetectionHistoricalDataOlderThanUnitMeasure;
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

        #region AirConditioning
        public ActionResult AirConditioning()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                return View(smartHouseEntities.AirConditioningSettings.FirstOrDefault());
            }
            else
            {
                return View(new List<AirConditioningSettings>().FirstOrDefault());
            }
        }

        [HttpPost]
        public JsonResult SaveAirConditioningSettings(AirConditioningSettings airConditioningSettings)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                smartHouseEntities.AirConditioningSettings.FirstOrDefault().AirConditioningOn = airConditioningSettings.AirConditioningOn;
                smartHouseEntities.AirConditioningSettings.FirstOrDefault().WantedTemperature = airConditioningSettings.WantedTemperature;
                smartHouseEntities.SaveChanges();

                if (smartHouseEntities.TemperatureHumidityDatas.Count() > 0 && (DateTime.Now - smartHouseEntities.TemperatureHumidityDatas.ToList().LastOrDefault().InternalTime).TotalMinutes <= 20)
                {
                    if (airConditioningSettings.WantedTemperature - 0.5 <= smartHouseEntities.TemperatureHumidityDatas.ToList().LastOrDefault().Temperature
                            && smartHouseEntities.TemperatureHumidityDatas.ToList().LastOrDefault().Temperature <= airConditioningSettings.WantedTemperature + 0.5)
                        smartHouseEntities.AirConditioningSettings.FirstOrDefault().AirConditioningMode = DictionaryAirConditioningMode.AutoMode;
                    else if (airConditioningSettings.WantedTemperature > smartHouseEntities.TemperatureHumidityDatas.ToList().LastOrDefault().Temperature + 0.5)
                        smartHouseEntities.AirConditioningSettings.FirstOrDefault().AirConditioningMode = DictionaryAirConditioningMode.HeatMode;
                    else if (airConditioningSettings.WantedTemperature < smartHouseEntities.TemperatureHumidityDatas.ToList().LastOrDefault().Temperature - 0.5)
                        smartHouseEntities.AirConditioningSettings.FirstOrDefault().AirConditioningMode = DictionaryAirConditioningMode.CoolMode;

                    smartHouseEntities.SaveChanges();
                    return Json(smartHouseEntities.AirConditioningSettings.ToList().FirstOrDefault(), JsonRequestBehavior.AllowGet);
                }
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
                    temperatureHumidityList = temperatureHumidityList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

                if (filter.DateMaxValue != null)
                    temperatureHumidityList = temperatureHumidityList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

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
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

                if (filter.DateMaxValue != null)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

                if (filter.TemperatureEmailAlertSent)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.TemperatureEmailAlertSent).ToList();

                if (filter.HumidityEmailAlertSent)
                    temperatureHumidityCriticalDataList = temperatureHumidityCriticalDataList.Where(x => x.HumidityEmailAlertSent).ToList();

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
                    motionDetectionList = motionDetectionList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

                if (filter.DateMaxValue != null)
                    motionDetectionList = motionDetectionList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

                if (filter.TemperatureEmailAlertSent)
                    motionDetectionList = motionDetectionList.Where(x => x.EmailAlertSent).ToList();

                motionDetectionList = motionDetectionList.OrderByDescending(x => x.InternalTime).ToList();

                return Json(motionDetectionList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<MotionDetectionData>(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FilterGasDetectionData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            if (smartHouseEntities.Database.Exists())
            {
                var gasDetectionList = smartHouseEntities.GasDetectionData.ToList();

                if (filter.DateMinValue != null)
                    gasDetectionList = gasDetectionList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

                if (filter.DateMaxValue != null)
                    gasDetectionList = gasDetectionList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

                if (filter.TemperatureEmailAlertSent)
                    gasDetectionList = gasDetectionList.Where(x => x.EmailAlertSent).ToList();

                gasDetectionList = gasDetectionList.OrderByDescending(x => x.InternalTime).ToList();

                return Json(gasDetectionList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new List<GasDetectionData>(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FilterSoundDetectionData(FilterTemperatureHumidityClass filter)
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            if (smartHouseEntities.Database.Exists())
            {
                var soundDetectionList = smartHouseEntities.SoundDetectionDatas.ToList();

                if (filter.DateMinValue != null)
                    soundDetectionList = soundDetectionList.Where(x => x.InternalTime.Date >= filter.DateMinValue.Value.Date).ToList();

                if (filter.DateMaxValue != null)
                    soundDetectionList = soundDetectionList.Where(x => x.InternalTime.Date <= filter.DateMaxValue.Value.Date).ToList();

                if (filter.TemperatureEmailAlertSent)
                    soundDetectionList = soundDetectionList.Where(x => x.EmailAlertSent).ToList();

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

        #region Charts
        public ActionResult Charts()
        {
            return View();
        }

        public ContentResult JSONTemperatureChartToday()
        {
            List<DataPoint> temperaturePoints = new List<DataPoint>();

            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                foreach (TemperatureHumidityData temperatureData in smartHouseEntities.TemperatureHumidityDatas)
                {
                    if (temperatureData.InternalTime.Date == DateTime.Now.Date)
                    {
                        DataPoint temperaturePoint = new DataPoint(temperatureData.InternalTime, Math.Round(Convert.ToDouble(temperatureData.Temperature), 2));
                        temperaturePoints.Add(temperaturePoint);
                    }
                }
            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return Content(JsonConvert.SerializeObject(temperaturePoints, _jsonSetting), "application/json");
        }

        public ContentResult JSONTemperatureChartAnotherDay(FilterTemperatureHumidityClass filter)
        {
            List<DataPoint> temperaturePoints = new List<DataPoint>();

            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                foreach (TemperatureHumidityData temperatureData in smartHouseEntities.TemperatureHumidityDatas)
                {
                    if (filter.DateMinValue.HasValue && temperatureData.InternalTime.Date == filter.DateMinValue.Value)
                    {
                        DataPoint temperaturePoint = new DataPoint(temperatureData.InternalTime, Math.Round(Convert.ToDouble(temperatureData.Temperature), 2));
                        temperaturePoints.Add(temperaturePoint);
                    }
                }
            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return Content(JsonConvert.SerializeObject(temperaturePoints, _jsonSetting), "application/json");
        }

        public ContentResult JSONHumidityChartToday()
        {
            List<DataPoint> humidityPoints = new List<DataPoint>();

            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                foreach (TemperatureHumidityData humidityData in smartHouseEntities.TemperatureHumidityDatas)
                {
                    if (humidityData.InternalTime.Date == DateTime.Now.Date)
                    {
                        DataPoint humidityPoint = new DataPoint(humidityData.InternalTime, Math.Round(Convert.ToDouble(humidityData.Humidity), 2));
                        humidityPoints.Add(humidityPoint);
                    }
                }
            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return Content(JsonConvert.SerializeObject(humidityPoints, _jsonSetting), "application/json");
        }

        public ContentResult JSONHumidityChartAnotherDay(FilterTemperatureHumidityClass filter)
        {
            List<DataPoint> humidityPoints = new List<DataPoint>();

            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            if (smartHouseEntities.Database.Exists())
            {
                foreach (TemperatureHumidityData humidityData in smartHouseEntities.TemperatureHumidityDatas)
                {
                    if (filter.DateMinValue.HasValue && humidityData.InternalTime.Date == filter.DateMinValue.Value)
                    {
                        DataPoint humidityPoint = new DataPoint(humidityData.InternalTime, Math.Round(Convert.ToDouble(humidityData.Humidity), 2));
                        humidityPoints.Add(humidityPoint);
                    }
                }
            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return Content(JsonConvert.SerializeObject(humidityPoints, _jsonSetting), "application/json");
        }

        public ContentResult JSONMotionDetection()
        {
            List<DataPoint> motionDetectionPoints = new List<DataPoint>();
            string month = String.Empty;
            int count = 0;

            DateTime target = new DateTime(DateTime.Now.Year, 1, 1);
            while (target < DateTime.Today)
            {
                switch (target.Month)
                {
                    case 1:
                        month = "January";
                        break;
                    case 2:
                        month = "February";
                        break;
                    case 3:
                        month = "March";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "June";
                        break;
                     case 7:
                        month = "July";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "October";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                }

                SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
                if (smartHouseEntities.Database.Exists())
                {
                    count = smartHouseEntities.MotionDetectionDatas.Count(x => x.InternalTime.Month == target.Month);
                }

                DataPoint motionDetectionPoint = new DataPoint(month, count);
                motionDetectionPoints.Add(motionDetectionPoint);

                target = target.AddMonths(1);
            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return Content(JsonConvert.SerializeObject(motionDetectionPoints, _jsonSetting), "application/json");
        }

        public ContentResult JSONSoundDetection()
        {
            List<DataPoint> soundDetectionPoints = new List<DataPoint>();
            string month = String.Empty;
            int count = 0;

            DateTime target = new DateTime(DateTime.Now.Year, 1, 1);
            while (target < DateTime.Today)
            {
                switch (target.Month)
                {
                    case 1:
                        month = "January";
                        break;
                    case 2:
                        month = "February";
                        break;
                    case 3:
                        month = "March";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "June";
                        break;
                    case 7:
                        month = "July";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "October";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                }

                SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
                if (smartHouseEntities.Database.Exists())
                {
                    count = smartHouseEntities.SoundDetectionDatas.Count(x => x.InternalTime.Month == target.Month);
                }

                DataPoint soundDetectionPoint = new DataPoint(month, count);
                soundDetectionPoints.Add(soundDetectionPoint);

                target = target.AddMonths(1);
            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return Content(JsonConvert.SerializeObject(soundDetectionPoints, _jsonSetting), "application/json");
        }

        public ContentResult JSONGasDetection()
        {
            List<DataPoint> gasDetectionPoints = new List<DataPoint>();
            string month = String.Empty;
            int count = 0;

            DateTime target = new DateTime(DateTime.Now.Year, 1, 1);
            while (target < DateTime.Today)
            {
                switch (target.Month)
                {
                    case 1:
                        month = "January";
                        break;
                    case 2:
                        month = "February";
                        break;
                    case 3:
                        month = "March";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "June";
                        break;
                    case 7:
                        month = "July";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "October";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                }

                SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
                if (smartHouseEntities.Database.Exists())
                {
                    count = smartHouseEntities.GasDetectionData.Count(x => x.InternalTime.Month == target.Month);
                }

                DataPoint gasDetectionPoint = new DataPoint(month, count);
                gasDetectionPoints.Add(gasDetectionPoint);

                target = target.AddMonths(1);
            }

            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return Content(JsonConvert.SerializeObject(gasDetectionPoints, _jsonSetting), "application/json");
        }
    #endregion

        #region Air Conditioning
        public JsonResult GetLastTemperatureDetected()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();

            if (smartHouseEntities.Database.Exists())
            {
                var lastDetectedTemperature = smartHouseEntities.TemperatureHumidityDatas.ToList().Where(x => (DateTime.Now - x.InternalTime).TotalMinutes <= 20).OrderByDescending(x => x.InternalTime).FirstOrDefault();

                if (lastDetectedTemperature != null)
                    return Json(lastDetectedTemperature, JsonRequestBehavior.AllowGet);

                return Json(new TemperatureHumidityData(), JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new TemperatureHumidityData(), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}