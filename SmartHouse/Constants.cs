using SmartHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartHouse
{
    public static class Constants
    {
        private static List<KeyValuePair<int, string>> _DictionaryTime = null;
        public static List<KeyValuePair<int, string>> DictionaryTime
        {
            get
            {
                if (_DictionaryTime == null)
                {
                    _DictionaryTime = new List<KeyValuePair<int, string>>()
                        {
                            new KeyValuePair<int, string>(1, "MINUTE"),
                            new KeyValuePair<int, string>(2, "HOUR"),
                            new KeyValuePair<int, string>(3, "DAY"),
                            new KeyValuePair<int, string>(4, "MONTH")
                        };
                }

                return _DictionaryTime;
            }
        }
    }
}