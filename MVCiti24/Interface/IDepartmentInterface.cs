using MVCiti24.Models;

namespace MVCiti24.Interface
{
    public interface IDepartmentInterface
    {
        void Add(Department department);

        void Delete(int id);

        void Update(Department department);

        List<Department> GetAll();

        Department GetById(int id);
        void save();
    }
}
