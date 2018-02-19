using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Temperature & Humidity
        public ActionResult TemperatureHumidity()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var temperatureHumidityList = smartHouseEntities.TemperatureHumidityDatas.ToList().Take(10);
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
            var motionDetectionList = smartHouseEntities.MotionDetectionDatas.ToList().Take(10);
            return View(motionDetectionList);
        }

        public JsonResult GetMotionDetectionHistoryData()
        {
            SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
            var motionDetectionList = smartHouseEntities.MotionDetectionDatas.ToList().OrderByDescending(x => x.InternalTime);
            return Json(motionDetectionList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult SoundDetection()
        {
            return View();
        }
    }
}