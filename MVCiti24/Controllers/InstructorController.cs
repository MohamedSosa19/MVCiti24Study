using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCiti24.Models;
using MVCiti24.ViewModels;

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

        public IActionResult AddInstructor()
        {
            List<Department> DepartmentList = contectDB.Departments.ToList();
            List<Course> CoursesList = contectDB.Courses.ToList();
            Instructor instructor = new Instructor();
            InstructorWithDeptCourseList instructorVM= new InstructorWithDeptCourseList();
            //Mapping to make VM As instructor Model
            instructorVM.Id = instructor.Id;
            instructorVM.Name=instructor.Name;
            instructorVM.Image=instructor.Image;
            instructorVM.Address=instructor.Address;
            instructorVM.Salary=instructor.Salary;
            instructorVM.DepartmentId = instructor.DepartmentId;
            instructorVM.CourseId=instructor.CourseId;
            instructorVM.DeptList=DepartmentList;
            instructorVM.CourseList = CoursesList;
            return View("AddInstructor", instructorVM);
        }

  
        [HttpPost]
        public IActionResult SaveInstructor(InstructorWithDeptCourseList instructorVM)
        {
            if (ModelState.IsValid)
            {
                Instructor instructor = new Instructor
                {
                    Name = instructorVM.Name,
                    Image = instructorVM.Image,
                    Salary = instructorVM.Salary,
                    Address = instructorVM.Address,
                    DepartmentId = instructorVM.DepartmentId,
                    CourseId = instructorVM.CourseId
                };

                contectDB.Instructors.Add(instructor);
                contectDB.SaveChanges();
                return RedirectToAction("AllInstructor");
            }

 
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            instructorVM.DeptList = contectDB.Departments.ToList();
            instructorVM.CourseList = contectDB.Courses.ToList();

            return View("AddInstructor", instructorVM);
        }


        public IActionResult EditInstructor(int Id)
        {
            List<Department> DepartmentList = contectDB.Departments.ToList();
            List<Course> CoursesList = contectDB.Courses.ToList();
            Instructor instructor = contectDB.Instructors.FirstOrDefault(e => e.Id == Id);
            InstructorWithDeptCourseList instructorVM = new InstructorWithDeptCourseList();

            instructorVM.Id = instructor.Id;
            instructorVM.Name = instructor.Name;
            instructorVM.Image = instructor.Image;
            instructorVM.Address = instructor.Address;
            instructorVM.Salary = instructor.Salary;
            instructorVM.DepartmentId = instructor.DepartmentId;
            instructorVM.CourseId = instructor.CourseId;
            instructorVM.DeptList = DepartmentList;
            instructorVM.CourseList = CoursesList;
            return View("EditInstructor", instructorVM);
        }

        [HttpPost]
        public IActionResult EditInstructor(int Id, InstructorWithDeptCourseList instructorVM)
        {
            if(ModelState.IsValid)
            {
                Instructor instructor = contectDB.Instructors.FirstOrDefault(e => e.Id == Id);
                instructor.Id = instructorVM.Id;
                instructor.Name = instructorVM.Name;
                instructor.Image= instructorVM.Image;
                instructor.Address= instructorVM.Address;
                instructor.Salary= instructorVM.Salary;
                instructor.DepartmentId= instructorVM.DepartmentId;
                instructor.CourseId= instructorVM.CourseId;
                contectDB.SaveChanges();
                return RedirectToAction("AllInstructor");
            }
            instructorVM.DeptList = contectDB.Departments.ToList();
            instructorVM.CourseList = contectDB.Courses.ToList();
            return View("EditInstructor", instructorVM);
        }


        public IActionResult SearchInstructor(string query)
        {
            List<Instructor> instructors;

            if (string.IsNullOrEmpty(query))
            {
                // If the query is empty, return all instructors
                instructors = contectDB.Instructors
                    .Include(d => d.Department)
                    .Include(c => c.Course)
                    .ToList();
            }
            else
            {

                instructors = contectDB.Instructors
                    .Include(d => d.Department)
                    .Include(c => c.Course)
                    .Where(i => i.Name.Contains(query))
                    .ToList();
            }

            return View("AllInstructor", instructors);
        }

    }
}
