using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediReports.Models
{
    //day of treatments
    public class Tipulim
    {
        //treatment day number
        public int TipID { get; set; }

        //report number
        public int TipRepID { get; set; }

        //the paramedic number 
        public int TipParamedicID { get; set; }

        //the school number
        public int TipSchoolID { get; set; }

        //date of treatment day
        public DateTime TipDate { get; set; }

        //start working hour
        public DateTime TipStartHour { get; set; }

        //end working hour
        public DateTime TipEndHour { get; set; }

        //total treatments for day
        public int TipTotal { get; set; }
    }
}