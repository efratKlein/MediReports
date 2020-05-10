using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediReports.Models
{
    public class School
    {
        //school number
        public int SchoolID { get; set; }

        //school name
        public string SchoolName { get; set; }

        //external institution icon
        public int SchoolExtSemel { get; set; }

        //internal institution icon
        public int SchoolIntSemel { get; set; }

        //city of the school
        public string SchoolState { get; set; }

        //the Manager of the school 
        public int SchoolManagerID { get; set; }
    }
}