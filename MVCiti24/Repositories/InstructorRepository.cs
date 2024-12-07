using Microsoft.EntityFrameworkCore;
using MVCiti24.Interface;
using MVCiti24.Models;

namespace MVCiti24.Repositories
{
    public class InstructorRepository : IInstructorInterface
    {
        private readonly ITIContectDB _dbcontext;

        public InstructorRepository(ITIContectDB dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Add(Instructor instructor)
        {
            _dbcontext.Add(instructor);
        }

        public void Delete(int id)
        {
            Instructor instr = GetById(id);
            _dbcontext.Remove(instr);
        }

        //public List<Instructor> GetAll()
        //{
        //    return _dbcontext.Instructors.ToList();
        //}

        public Instructor GetById(int id)
        {
            return _dbcontext.Instructors.FirstOrDefault(i => i.Id == id);
        }

        public void save()
        {
            _dbcontext.SaveChanges();
        }

        public void Update(Instructor instructor)
        {
            _dbcontext.Update(instructor);
        }

        public IQueryable<Instructor> GetAll()
        {
            return _dbcontext.Instructors.Include(i => i.Department).Include(i => i.Course);
        }

    }
}
