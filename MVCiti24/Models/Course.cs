using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCiti24.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="Name Min Length must be 2")]
        [MaxLength(35, ErrorMessage = "Name Max Length must be 35")]
        [UniqueName]
        public string Name { get; set; }
        [Range(50,250)]
        public int Degree { get; set; }
        [Range(25,125)]
        [Remote(action: "CheckDegree", controller: "Course", AdditionalFields = nameof(Degree),
        ErrorMessage = "MinDegree must be less than Degree.")]
        public int MinDegree { get; set; }
        public int Hour { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("CrsResults")]
        public int? CrsResultsId { get; set; }
        //Navigational Property
        public Department? Department { get; set; }

        public List<Instructor>? Instructors { get; set; }

        public CrsResults? CrsResults { get; set; }
    }
}
