using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediReports.Models
{
    public class Note
    {
        //note number
        public int NoteID { get; set; }

        //note in report number
        public int NoteRepID { get; set; }

        //note details
        public string NoteDetails { get; set; }
    }
}