using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediReports.Models
{
    public class ManagerAccept
    {
        //acception number
        public int AccID { get; set; }

        //treatment day number in the acception
        public int AccTipID { get; set; }

        //the manager id number
        public int AccManagerID { get; set; }

        //acception date
        public DateTime AccDate { get; set; }

        //note
        public string AccNote { get; set; }
    }
}