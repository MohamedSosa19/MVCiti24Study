using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCiti24.Models;

namespace MVCiti24.Controllers
{
    public class CourseController : Controller
    {
        ITIContectDB contectDB = new ITIContectDB();
        private const int PageSize = 10;

    

        public IActionResult CheckDegree(int MinDegree, int Degree)
        {
            // Return false (invalid) if MinDegree is greater than Degree, true (valid) otherwise
            if (MinDegree < Degree)
                return Json(true);  // Valid
            else
                return Json(false); // Invalid
        }

        public IActionResult AllCourses(int pageNumber = 1)
        {
            var totalCourses = contectDB.Courses.Count();

            var startItem = ((pageNumber - 1) * PageSize) + 1;
            var endItem = Math.Min(pageNumber * PageSize, totalCourses);


            List<Course> courses = contectDB.Courses
                .Include(d => d.Department)
                .Skip((pageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            // Pass pagination info to the view
            ViewData["CurrentPage"] = pageNumber;
            ViewData["TotalPages"] = (int)Math.Ceiling((double)totalCourses / PageSize);
            ViewData["TotalCourses"] = totalCourses;
            ViewData["StartItem"] = startItem;
            ViewData["EndItem"] = endItem;

            return View("AllCourses", courses);
        }

        public IActionResult Details(int id)
        {
            Course courseDetails = contectDB.Courses.Include(d => d.Department).FirstOrDefault(c=>c.Id==id);

            return View("Details", courseDetails);
        }


        public IActionResult AddCourse()
        {
            ViewData["DeptList"]=contectDB.Departments.ToList();
            ViewData["CrsResultsList"] = contectDB.CrsResults.ToList();
            return View("AddCourse");
        }


        [HttpPost]
        public IActionResult SaveCourse(Course courseObj)
        {
            if (ModelState.IsValid)
            {
                contectDB.Courses.Add(courseObj);
                contectDB.SaveChanges();
                return RedirectToAction("AllCourses");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            ViewData["DeptList"] = contectDB.Departments.ToList();
            ViewData["CrsResultsList"] = contectDB.CrsResults.ToList();
            return View("AddCourse", courseObj);
        }


        public IActionResult EditCourse(int Id)
        {
            ViewData["DeptList"] = contectDB.Departments.ToList();
            ViewData["CrsResultsList"] = contectDB.CrsResults.ToList();
            Course course= contectDB.Courses.FirstOrDefault(c=> c.Id == Id);
            return View("EditCourse", course);
        }

        [HttpPost]
        public IActionResult EditCourse(int Id, Course courseObj)
        {
            if(ModelState.IsValid)
            {
                Course course = contectDB.Courses.FirstOrDefault(c => c.Id == Id);
                course.Name = courseObj.Name;
                course.Degree = courseObj.Degree;
                course.MinDegree = courseObj.MinDegree;
                course.Hour = courseObj.Hour;
                course.DepartmentId = courseObj.DepartmentId;
                course.CrsResultsId = courseObj.CrsResultsId;
                contectDB.SaveChanges();
                return RedirectToAction("AllCourses");
            }
            ViewData["DeptList"] = contectDB.Departments.ToList();
            ViewData["CrsResultsList"] = contectDB.CrsResults.ToList();
            return View("EditCourse", courseObj);
        }


        public IActionResult DeleteCourse(int Id)
        {
           
            Course course = contectDB.Courses.FirstOrDefault(c => c.Id == Id);
            return View("DeleteCourse", course);
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            Course course = contectDB.Courses.FirstOrDefault(c => c.Id == Id);
            if (course != null)
            {
                contectDB.Courses.Remove(course);
                contectDB.SaveChanges();
            }
            return RedirectToAction("AllCourses");
        }
    }
}
