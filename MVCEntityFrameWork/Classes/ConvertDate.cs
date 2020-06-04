using MD.PersianDateTime.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEntityFrameWork.Classes
{
    public class ConvertDate
    {
        public string ConvertMiladiToShamsi(DateTime datetime)
        {
            PersianDateTime persianDateTime = new PersianDateTime(datetime);
            return persianDateTime.ToString("yyyy/MM/dd");
            //return persianDateTime.ToString("dddd d MMMM yyyy");
        }

        public DateTime ConvertShamsiToMiladi(string datetime)
        {
            PersianDateTime persianDateTime = PersianDateTime.Parse(datetime);
            return persianDateTime.ToDateTime();
        }
    }
}
