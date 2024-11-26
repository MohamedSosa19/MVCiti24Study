using MVCiti24.Interface;
using MVCiti24.Models;

namespace MVCiti24.Repositories
{
    public class CourseRepository : ICourseInterface

    {
        ITIContectDB dbcontext;
        public CourseRepository()
        {
            dbcontext=new ITIContectDB();
        }
        public void Add(Course course)
        {
            dbcontext.Add(course);
        }

        public void Delete(int id)
        {
            Course cours= GetById(id);
            dbcontext.Remove(cours);

        }

        public List<Course> GetAll()
        {
           return dbcontext.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return dbcontext.Courses.FirstOrDefault(c=>c.Id==id);
        }

        public void save()
        {
            dbcontext.SaveChanges();
        }

        public void Update(Course course)
        {
            dbcontext.Update(course);
        }
    }
}
