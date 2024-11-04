using System.ComponentModel.DataAnnotations.Schema;

namespace MVCiti24.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hour { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("CrsResults")]
        public int? CrsResultsId { get; set; }
        //Navigational Property
        public Department Department { get; set; }

        public List<Instructor> Instructors { get; set; }

        public CrsResults CrsResults { get; set; }
    }
}
