using MVCiti24.Models;

namespace MVCiti24.Interface
{
    public interface InstructorInterface
    {
        void Add(Instructor instructor);

        void Delete(int id);

        void Update(Instructor instructor);

        List<Instructor> GetAll();

        Instructor GetById(int id);
        void save();
      
    }
}
