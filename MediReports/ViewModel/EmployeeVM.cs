using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediReports.Models;

namespace MediReports.ViewModel
{
    public class EmployeeVM
    {
        public Employee Emp { get; set; }
        public List<Employee> Employees { get; set; }
    }
}