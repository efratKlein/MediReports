using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediReports.Models;
using MediReports.DAL;
using MediReports.ViewModel;
using System.Threading;

namespace MediReports.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        /*     public ActionResult Load()
             {
                 Employee emp = new Employee
                 {
                     EmpNum =16,
                     EmpType =3,
                     EmpFirstName ="חגית",
                     EmpLastName ="לוי",
                     EmpID ="253112653",
                     EmpPass =1596,
                     EmpEmail="chl@cha.org.il"
                 };

                 return View("Employee",emp);
             }*/



        public ActionResult AddEmployee()
        {    
            return View();
        }
        public ActionResult AddEmployeesByJson()
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<Employee> LE = new List<Employee>();
            Employee e = new Employee();
            string id = e.AddZero(Request.Form["EmpId"]);
            if (ModelState.IsValid)
            {
                if (e.ChechIDS(id))
                {
                    if (e.CheckIDNo(id))
                    {
                        {
                            e.EmpEmail = Request.Form["EmpEmail"];
                            e.EmpFirstName = Request.Form["EmpFirstName"];
                            e.EmpID = id;
                            e.EmpLastName = Request.Form["EmpLastName"];
                            e.EmpNum = Int32.Parse(Request.Form["EmpNum"]);
                            e.EmpPass = Int64.Parse(Request.Form["EmpPass"]);
                            e.EmpType = Int32.Parse(Request.Form["EmpType"]);
                        }
                        dal.Employees.Add(e);
                        dal.SaveChanges();
                        LE = dal.Employees.ToList<Employee>();
                    }
                    else
                    {
                        e.EmpID = id;
                        e.EmpFirstName = "notLigal";
                        LE.Add(e);
                    }
                }
                else
                {
                    e.EmpID = id;
                    e.EmpFirstName = "exsist";
                    LE.Add(e);
                }
            }
            return Json(LE, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Submit()
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<Employee> LE = new List<Employee>();
            Employee e = new Employee();
            string id = e.AddZero(Request.Form["EmpId"]);
            if (ModelState.IsValid)
            {
                if (e.ChechIDS(id))
                {
                    if (e.CheckIDNo(id))
                    {
                        {
                            e.EmpEmail = Request.Form["EmpEmail"];
                            e.EmpFirstName = Request.Form["EmpFirstName"];
                            e.EmpID = id;
                            e.EmpLastName = Request.Form["EmpLastName"];
                            e.EmpNum = Int32.Parse(Request.Form["EmpNum"]);
                            e.EmpPass = Int64.Parse(Request.Form["EmpPass"]);
                            e.EmpType = Int32.Parse(Request.Form["EmpType"]);
                        }
                        dal.Employees.Add(e);
                        dal.SaveChanges();
                        LE = dal.Employees.ToList<Employee>();
                    }
                    else
                    {
                        e.EmpID = id;
                        e.EmpFirstName = "notLigal";
                        LE.Add(e);
                    }
                }
                else
                {
                    e.EmpID = id;
                    e.EmpFirstName = "exsist";
                    LE.Add(e);
                }
            }
            return Json(LE, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Show()
        {
            EmployeeDAL dal = new EmployeeDAL();
            EmployeeVM evm = new EmployeeVM();
            evm.Employees = dal.Employees.ToList<Employee>();
            return View(evm);
        }
        public ActionResult GetEmployeesByJson()
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<Employee> LE = new List<Employee>();
            LE = dal.Employees.ToList<Employee>();
            return Json(LE, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            EmployeeVM evm = new EmployeeVM();
            evm.Employees = new List<Employee>();
            return View(evm);

        }
        public ActionResult ShowSearch()
        {
            EmployeeDAL dal = new EmployeeDAL();
            string searchVal = Request.Form["TXT"].ToString();
            string searchBy = Request.Form["SearchBy"].ToString();
            List<Employee> SLE = new List<Employee>();
            switch (searchBy)
            {
                case "FirstName":
                    SLE = (from x in dal.Employees
                           where x.EmpFirstName.StartsWith(searchVal)
                           select x).ToList<Employee>();
                    break;
                case "LastName":
                    SLE = (from x in dal.Employees
                           where x.EmpLastName.StartsWith(searchVal)
                           select x).ToList<Employee>();
                    break;


            }
            return Json(SLE, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchEmployeesByJson()
        {
            EmployeeDAL dal = new EmployeeDAL();
            string searchVal = Request.Form["TXT"].ToString();
            string searchBy = Request.Form["SearchBy"].ToString();
            List<Employee> SLE = new List<Employee>();
            switch (searchBy)
            {
                case "FirstName":
                    SLE = (from x in dal.Employees
                           where x.EmpFirstName.StartsWith(searchVal)
                           select x).ToList<Employee>();
                    break;
                case "LastName":
                    SLE = (from x in dal.Employees
                           where x.EmpLastName.StartsWith(searchVal)
                           select x).ToList<Employee>();
                    break;

            }
            return Json(SLE, JsonRequestBehavior.AllowGet);


        }

        public ActionResult DeleteEmployee()
        {
            EmployeeVM evm = new EmployeeVM();
            evm.Employees = new List<Employee>();
            return View(evm);
        }
        public ActionResult DeleteEmployeeByJson()
        {
            EmployeeDAL dal = new EmployeeDAL();
            Employee emp = new Employee();
            string delID = emp.AddZero(Request.Form["TXTID"].ToString());
            List<Employee> DEM = (from x in dal.Employees
                                  where x.EmpID == delID
                                  select x).ToList<Employee>();
            if (emp.CheckIDNo(delID))
            {
                if (DEM.Count != 0)
                {
                    dal.Employees.Remove(DEM[0]);
                    dal.SaveChanges();
                }

                else
                {
                    emp.EmpID = delID;
                    emp.EmpFirstName = "notExist";
                    DEM.Add(emp);
                }
            }
            else
            {
                emp.EmpID = delID;
                emp.EmpFirstName = "notLigal";
                DEM.Add(emp);
            }

            return Json(DEM, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete()
        {
            EmployeeDAL dal = new EmployeeDAL();
            Employee emp = new Employee();
            string delID = emp.AddZero(Request.Form["TXTID"].ToString());           
            List<Employee> DEM = (from x in dal.Employees
                                  where x.EmpID == delID
                                  select x).ToList<Employee>();
            if (emp.CheckIDNo(delID))
            {
                if (DEM.Count != 0)
                {
                    dal.Employees.Remove(DEM[0]);
                    dal.SaveChanges();
                }

                else
                {
                    emp.EmpID = delID;
                    emp.EmpFirstName = "notExist";
                    DEM.Add(emp);
                }
            }
            else
            {
                emp.EmpID = delID;
                emp.EmpFirstName = "notLigal";
                DEM.Add(emp);
            }
            

            return Json(DEM, JsonRequestBehavior.AllowGet);
        }

        public ActionResult updateEmployee()
        {
            return View();
        }

    }
}