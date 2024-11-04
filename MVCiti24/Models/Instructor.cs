using System.ComponentModel.DataAnnotations.Schema;

namespace MVCiti24.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        //Navigational Property

        public Department Department { get; set; }
        public Course Course { get; set; }
    }
}
