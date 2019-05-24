using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Utils
{
    public static class Dateime
    {
        public static long GetTimestamp(DateTime dateTime)
        {
            return (dateTime.Ticks - 621355968000000000) / 10000;
        }
        public static long GetNowTimestamp()
        {
            return (DateTime.Now.Ticks - 621355968000000000) / 10000;
        }
    }
}
