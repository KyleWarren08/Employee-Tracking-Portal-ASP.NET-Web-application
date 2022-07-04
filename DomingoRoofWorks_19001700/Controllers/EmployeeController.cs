using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomingoRoofWorks_19001700.Models;
using DomingoRoofWorks_19001700.Repository;

namespace DomingoRoofWorks_19001700.Controllers
{
    public class EmployeeController : Controller
    {

        //GET Employee/GET All Employees
        public ActionResult GetAllEmployees()
        {
            DomingoRepository EmployeeRepo = new DomingoRepository();
            ModelState.Clear();
            return View(EmployeeRepo.GetAllEmployees());
        }
        //GET: Employees/ Return Employee View

        public ActionResult AddEmployee()
        {
            return View();
        }
        //POST:Emplployee/Add Employee
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel EMP)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DomingoRepository EmployeeRepo = new DomingoRepository();
                    if (EmployeeRepo.AddEmployee(EMP))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //GET: Employee/Return Edit Employee View
        public ActionResult EditEmployee(String ID)
        {
            DomingoRepository EmployeeRepo = new DomingoRepository();
            return View(EmployeeRepo.GetAllEmployees().Find(EMP => EMP.Employee_ID == ID));
        }

        //POST Employee/Edit Existing Employee
        [HttpPost]
        public ActionResult EditEmployee(String ID, EmployeeModel obj)
        {
            try
            {
                DomingoRepository EmployeeRepo = new DomingoRepository();
                EmployeeRepo.UpdateEmployee(obj);

                return RedirectToAction("GetAllEmployees");
            }
            catch
            {
                return View();
            }
        }
        //GET : Employee/Delete Employee

        public ActionResult DeleteEmployee(String ID)
        {
            try
            {
                DomingoRepository EmployeeRepo = new DomingoRepository();
                if (EmployeeRepo.DeleteEmployee(ID))
                {
                    ViewBag.AlertMsg = "Employee details deleted succesfully";
                }
                return RedirectToAction("GetAllEmployees");
            }
            catch
            {
                return View();
            }

        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------

        //GET Job_Cards/GET All Job_Cards
        public ActionResult GetAllJob_Cards()
        {
            DomingoRepository Job_CardRepo = new DomingoRepository();
            ModelState.Clear();
            return View(Job_CardRepo.GetAllJob_Cards());
        }
        //GET: Job_Cards/ Return Job_Cards View

        public ActionResult AddJob_Card()
        {
            return View();
        }
        //POST:Job_Cards/Add Job_Cards
        [HttpPost]
        public ActionResult AddJob_Card(Job_CardModel JC)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DomingoRepository Job_CardRepo = new DomingoRepository();
                    if (Job_CardRepo.AddJob_Card(JC))
                    {
                        ViewBag.Message = "Job Card details added successfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        //Delete Job Cards
        public ActionResult DeleteJob_Card(String ID)
        {
            try
            {
                DomingoRepository Job_CardRepo = new DomingoRepository();
                if (Job_CardRepo.DeleteJob_Card(ID))
                {
                    ViewBag.AlertMsg = "Job_Card details deleted succesfully";
                }
                return RedirectToAction("GetAllJob_Cards");
            }
            catch
            {
                return View();
            }

        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //GET Invoices/GET All Invoices
        public ActionResult GetAllInvoices()
        {
            DomingoRepository InvoiceRepo = new DomingoRepository();
            ModelState.Clear();
            return View(InvoiceRepo.GetAllInvoices());
        }
        //GET: Invoice/ Return Invoice View

        public ActionResult AddInvoices()
        {
            return View();
        }
        //POST:Invoice/Add Invoice
        [HttpPost]
        public ActionResult AddInvoices(InvoiceModel IN)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DomingoRepository InvoiceRepo = new DomingoRepository();
                    if (InvoiceRepo.AddInvoice(IN))
                    {
                        ViewBag.Message = "Invoice details added successfully";
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        //Delete Invoice
        public ActionResult DeleteInvoice(String ID)
        {
            try
            {
                DomingoRepository InvoiceRepo = new DomingoRepository();
                if (InvoiceRepo.DeleteInvoice(ID))
                {
                    ViewBag.AlertMsg = "Invoice details deleted succesfully";
                }
                return RedirectToAction("GetAllInvoices");
            }
            catch
            {
                return View();
            }

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //GET Job_Types/GET All Job_Types
        public ActionResult GetAllJob_Types()
        {
            DomingoRepository Job_TypeRepo = new DomingoRepository();
            ModelState.Clear();
            return View(Job_TypeRepo.GetAllJob_Types());
        }

        //GET: Job_Type/Return Edit Job_Type View
        public ActionResult EditJob_Type(String ID)
        {
            DomingoRepository Job_TypeRepo = new DomingoRepository();
            return View(Job_TypeRepo.GetAllJob_Types().Find(JT => JT.Job_Type_ID == ID));
        }

        //POST Job_Type/Edit Existing Job_Type
        [HttpPost]
        public ActionResult EditJob_Type(String ID, Job_TypeModel obj)
        {
            try
            {
                DomingoRepository Job_TypeRepo = new DomingoRepository();
                Job_TypeRepo.UpdateJob_Type(obj);

                return RedirectToAction("GetAllJob_Types");
            }
            catch
            {
                return View();
            }
        }

    }
}
