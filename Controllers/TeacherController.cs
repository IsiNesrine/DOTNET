using Microsoft.AspNetCore.Mvc;
using mvc.Models;
namespace mvc.Controllers
{
    public class TeacherController : Controller
    {
        // GET: TeacherController

        private static List<Teacher> teachers = new(){
            new() {Id = 1, Major = Major.MATH,Firstname = "Jhon", Lastname = "Doe"},
            new() {Id = 2, Major = Major.CS,Firstname = "Jhon", Lastname = "Doe"},
            new() {Id = 3, Major = Major.IT,Firstname = "Jhon", Lastname = "Doe"}
        };

        public ActionResult Index()
        {
            return View(teachers);
        }

    }
}
