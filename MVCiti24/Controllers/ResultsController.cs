using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCiti24.Models;

namespace MVCiti24.Controllers
{
    public class ResultsController : Controller
    {
        ITIContectDB contectDB = new ITIContectDB();
        public IActionResult Result(int traineeId,int courseId)
        {
            var results=contectDB.CrsResults.Include(cr=>cr.Trainees).
                        Include(cr=>cr.Courses).
                        FirstOrDefault(cr=>cr.TraineeId==traineeId && cr.CourseId==courseId);

            if (results is null)
                return NotFound("results Not Found");

            var course=contectDB.Courses.FirstOrDefault(c=>c.Id==courseId);
            var trainee = contectDB.Trainees.FirstOrDefault(t=>t.Id==traineeId);

            var ResultsVM = new TraineeResults
            {
                TraineeName = trainee?.Name,
                CourseName=course?.Name,
                Degree=results.Degree,
                MinDegree=course?.MinDegree??0,
                IsSuccessful= results.Degree >= (course?.MinDegree ?? 0)
            };

            return View("Result", ResultsVM);
        }
    }
}
