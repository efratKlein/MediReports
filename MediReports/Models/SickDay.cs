using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediReports.Models
{
    public class SickDay
    {
        //illness approval  number
        public static int SickID { get; set; }

        //sick approval in report number
        public int SickRepID { get; set; }

        //illness approval date
        public DateTime SickDate { get; set; }

        //illness approval path address
        public string SickFilePath { get; set; }
    }
}