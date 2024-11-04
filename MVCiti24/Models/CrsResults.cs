using System.ComponentModel.DataAnnotations.Schema;

namespace MVCiti24.Models
{
    public class CrsResults
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        [ForeignKey("Trainee")]
        public int? TraineeId { get; set; }

        //Navigational Property

        public List<Course> Courses { get; set; }

        public List<Trainee> Trainees { get; set; }
    }
}
