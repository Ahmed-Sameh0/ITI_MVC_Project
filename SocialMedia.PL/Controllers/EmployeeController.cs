using Microsoft.AspNetCore.Mvc;
using SocialMedia.BLL.Helper;
using SocialMedia.BLL.ModelVM.EmployeeVM;
using SocialMedia.DAL.DataBase;
using SocialMedia.DAL.Entities;
namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SaveData(CreateEmployeeVM emp)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Please provide valid name and age.";
                return View("Create");
            }
            string Image;
            if (emp.Image == null)
            {
                Image = null;
            }
            else
            {
                Image = Upload.UploadFile("Files", emp.Image);
            }
            var map = new Employee
            {
                Name = emp.Name,
                Age = emp.Age,
                ImagePath = Image
            };

            db.Employees.Add(map);
            db.SaveChanges();

            return RedirectToAction("GetAll", "Employee");

        }

        public IActionResult GetAll()
        {
            var employees = db.Employees.Select(a => new GetAllEmployeeVM()
            {
                Id = a.Id,
                Age = a.Age,
                Name = a.Name,
                ImagePath = a.ImagePath

            }).ToList();
            return View(employees);
        }


        public IActionResult Edit(int id)
        {
            var user = db.Employees.Where(emp => emp.Id == id).FirstOrDefault();

            if (user == null)
            {
                ViewBag.HomeMessage = "User not found.";
                return View();
            }
            return View(user);
        }

        public IActionResult SaveEditData(Employee newEmp)
        {
            var olduser = db.Employees.Where(emp => emp.Id == newEmp.Id).FirstOrDefault();

            if (olduser == null)
            {
                ViewBag.HomeMessage = "User not found.";
                return View("Edit");
            }

            olduser.Name = newEmp.Name;
            olduser.Age = newEmp.Age;
            db.SaveChanges();
            return RedirectToAction("GetAll", "Employee");
        }


        public IActionResult Delete(Employee Emp)
        {
            var DeletedUser = db.Employees.Where(emp => emp.Id == Emp.Id).FirstOrDefault();

            if (DeletedUser == null)
            {
                ViewBag.HomeMessage = "User not found.";
                return View("GetAll");
            }
            db.Employees.Remove(DeletedUser);
            db.SaveChanges();
            return RedirectToAction("GetAll", "Employee");
        }

    }
}
