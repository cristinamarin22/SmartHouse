using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    public static class Dictionary
    {
        private static IEnumerable<object> _TimeDictionary = null;
        public static IEnumerable<object> TimeDictionary
        {
            get
            {
                if (_TimeDictionary == null)
                {
                    SmartHouseEntities smartHouseEntities = new SmartHouseEntities();
                    _TimeDictionary = smartHouseEntities.DictionaryTime;
                }

                return _TimeDictionary;
            }
        }
    }
}