using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RegistrationForm.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Emplyee
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(Employee employee)
        {
            Employee user = new Employee();
            user.FirstName = employee.FirstName;
            user.LastName = employee.LastName;
            user.MobileNumber = employee.MobileNumber;
            user.Email = employee.Email;
            user.Address = employee.Address;
            user.DateOfBirth = employee.DateOfBirth.ToString();
            user.Gender = employee.Gender;
            user.Hobby = employee.Hobby;
            user.Password = employee.Password;
            if (ModelState.IsValid)
            {
                employee.Register(user);
                return Json(new { success = true, message = "User added successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Error" });

            }
        }
    }
}