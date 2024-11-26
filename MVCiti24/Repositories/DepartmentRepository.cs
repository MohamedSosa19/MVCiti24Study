using MVCiti24.Interface;
using MVCiti24.Models;

namespace MVCiti24.Repositories
{
    public class DepartmentRepository : IDepartmentInterface
    {
        ITIContectDB dbcontext;
        public DepartmentRepository()
        {
            dbcontext=new ITIContectDB();
        }
        public void Add(Department department)
        {
            dbcontext.Add(department);
        }

        public void Delete(int id)
        {
            Department dept=GetById(id);
            dbcontext.Remove(dept);

        }

        public List<Department> GetAll()
        {
            return dbcontext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return dbcontext.Departments.FirstOrDefault(d=>d.Id==id);
        }

        public void save()
        {
            dbcontext.SaveChanges();
        }

        public void Update(Department department)
        {
           dbcontext.Update(department);
        }
    }
}
