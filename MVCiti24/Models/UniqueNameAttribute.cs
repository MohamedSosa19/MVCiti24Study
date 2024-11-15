using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCiti24.Models
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
                return null;
            string newName=value.ToString();
            ITIContectDB dbContext = new ITIContectDB();
            Course course=dbContext.Courses.FirstOrDefault(c=>c.Name==newName);
            if(course != null)
            {
                return new ValidationResult("CourseName Must be Unique Not Exsits Befor!!");
            }
            return ValidationResult.Success;
        }
    }
}
