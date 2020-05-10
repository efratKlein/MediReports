using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediReports.Models
{
    //type of roles: Paranedic\Manager\Administrator
    public class RoleType
    {
        //role number
        [Key]
        [Required]
        [RegularExpression("^[1-3]$")]
        public int RoleTypeID { get; set; }

        //role name
        [RegularExpression("^[מטפל+מנהל בית הספר+מנהל מערכת]$")]
        public string RoleTypeName { get; set; }
    }
}