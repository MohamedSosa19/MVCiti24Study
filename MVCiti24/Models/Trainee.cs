using System.ComponentModel.DataAnnotations.Schema;

namespace MVCiti24.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }
        public string Address { get; set; }
        public string Grade { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        [ForeignKey("CrsResults")]
        public int? CrsResultsId { get; set; }

        //Navigational Property
        public CrsResults CrsResults { get; set; }

        public Department Department { get; set; }
    }
}
