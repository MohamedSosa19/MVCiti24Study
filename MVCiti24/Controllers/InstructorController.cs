using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCiti24.Models;

namespace MVCiti24.Controllers
{
    public class InstructorController : Controller
    {

        ITIContectDB contectDB=new ITIContectDB();
        public IActionResult AllInstructor()
        {
            List<Instructor> instructors = contectDB.Instructors
                .Include(d=>d.Department).Include(c=>c.Course).ToList();
            return View("AllInstructor",instructors);
        }

        public IActionResult Details(int id)
        {
            Instructor instructorDetails = contectDB.Instructors.Include(d=>d.Department).Include(c => c.Course).FirstOrDefault(e => e.Id == id);
               
            return View("Details", instructorDetails);
        }
    }
}
