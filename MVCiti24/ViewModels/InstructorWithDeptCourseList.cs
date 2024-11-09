using MVCiti24.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCiti24.ViewModels
{
    public class InstructorWithDeptCourseList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        [Range(2000,15000)]
        public int Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public List<Department> DeptList { get; set; } = new List<Department>();
        public List<Course> CourseList { get; set; } = new List<Course>();
    }
}
