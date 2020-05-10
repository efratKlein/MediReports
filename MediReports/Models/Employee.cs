using MediReports.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediReports.Models
{
    public class Employee
    {
        //employee number
        [Required(ErrorMessage = "נדרש מספר עובד")]
        public int EmpNum { get; set; }

        //Paranedic\Manager\Administrator - from the EmloyeeType Table
        [Required(ErrorMessage = "נדרש מספר תפקיד")]
        [RegularExpression("^[1-3]{1}$", ErrorMessage = "(הזן 1 (מנהל מערכת), 2 (מנהל בית ספר), או 3 (מטפל פרא רפואי")]
        public int EmpType { get; set; }

        //private name
        [Required(ErrorMessage = "נדרש שם פרטי")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "הזן תוים בין 2-25")]
        public string EmpFirstName { get; set; }

        //family name
        [Required(ErrorMessage = "נדרש שם משפחה")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "הזן תוים בין 2-25")]
        public string EmpLastName { get; set; }

        //identification number
        [Key]
        [Required(ErrorMessage = "נדרש מספר זהות")]
        public string EmpID { get; set; }

        //encrypted number
        [Required(ErrorMessage = "נדרש סיסמה")]
        public long EmpPass { get; set; }

        //email adress
        [Required(ErrorMessage = "נדרש כתובת אימייל")]
        //[RegularExpression("^[A-Za-z0-9][A-Za-z0-9]*@[a-z].[a-z]*$")]
        public string EmpEmail { get; set; }

        //is ligal ID
        public Boolean CheckIDNo(string strID)
        {
            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;

            if (strID == null)
                return false;

            strID = strID.PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }

            return (count % 10 == 0);
        }
        
        //adding zeros to the pre short id
        public string AddZero(string id)
        {
            if (id.Length < 9)
            {
                string a = "";
                for (int i = 0; i < 9 - id.Length; i++)
                {
                    a += "0";
                }
                id = a + id;
            }
            return id;
        }

        public Boolean ChechIDS(string id)
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<Employee> LE = (from x in dal.Employees
                                 where x.EmpID == id
                                 select x).ToList<Employee>();
            if(LE.Count==0)
            {
                return true;
            }
            return false;
        }

    }
}