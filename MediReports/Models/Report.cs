using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediReports.Models
{
    public class Report
    {
        //report number
        public int RepID { get; set; }

        //list of Tipulim
        public List<Tipulim> RepTipIDs { get; set; }

        //report date
        public DateTime RepDate { get; set; }

        //total periodic treatments
        public int RepTotalTip { get; set; }
    }
}