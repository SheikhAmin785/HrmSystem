using HrmSystem.Data;
using HrmSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrmSystem.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController(HrmContext context)
        {
            this.context = context;
        }


        public List<Employee> employees = new List<Employee>()
        {
            new Employee { EmployeeID = 1, FirstName = "Al-amin", LastName = "Sheikh",Salary = 60000,Company="Novatek"},
            new Employee { EmployeeID = 2, FirstName = "Jahir", LastName = "Sheikh", Salary = 50000,Company="Orion Group" },
            new Employee{ EmployeeID = 3, FirstName = "kabir", LastName = "Sayed", Salary = 70000,Company="Shanta Industry" }

        };
        private readonly HrmContext context;

        public IActionResult Index()
        {
            return View(employees);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                  EmployeeID=model.EmployeeID,
                  FirstName=model.FirstName,
                  LastName=model.LastName,
                  Company=model.Company,
                  Department=model.Department,
                  Designation=model.Designation,
                  Salary=model.Salary
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["error"] = "record saved";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "recod empty";
                return View(model);
            }

        }

        public IActionResult Delete(int model)
        {
            var employee = context.Employees.Where(e => e.EmployeeID == model).SingleOrDefault();

            if (employee == null)
            {
                return NotFound();
            }

            context.Employees.Remove(employee);
            context.SaveChanges();

            return RedirectToAction("Index");
        }





        [HttpPost]
        public IActionResult Edit(int Id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.EmployeeID == Id);
            var result = new Employee()
            {
                EmployeeID = emp.EmployeeID,
                FirstName = emp.FirstName,
                LastName =emp.LastName,
                Company=emp.Company,
                Department=emp.Department,
                Designation=emp.Designation,
                Salary = emp.Salary

            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                EmployeeID = model.EmployeeID,
                FirstName = model.FirstName,
                LastName=model.LastName,
                Company =model.Company,
                Department=model.Department,
                Designation=model.Designation,
                Salary = model.Salary

            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["eroor"] = "record updated";
            return RedirectToAction("index");

        }

        public IActionResult IncrementInfo(Employee model)
        {
            var q = (from inc in context.Increments
                     join em in context.Employees on
                inc.EmployeeID equals em.EmployeeID
                     orderby inc.IncrementID
                     select new
                     {
                         inc.IncrementID,
                         inc.IncrementDate,
                         inc.IncrementAmount,
                         em.FirstName,
                         em.LastName,
                         em.Salary

                     }).ToList();
           
            {
                return View(q);
            }
            
        }

        public ActionResult EmployeeJoiningInfo(DateTime startDate, DateTime endDate)
        {
            var employeeJoiningInfo = context.Employees
                .Where(e => e.JoiningDate >= startDate && e.JoiningDate <= endDate)
                .ToList();

            return View(employeeJoiningInfo);
        }



    }


}


