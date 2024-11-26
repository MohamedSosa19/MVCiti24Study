using MVCiti24.Models;

namespace MVCiti24.Interface
{
    public interface ICourseInterface
    {
        void Add(Course course);

        void Delete(int id);

        void Update(Course course);

        List<Course> GetAll();

        Course GetById(int id);
        void save();
    }
}
