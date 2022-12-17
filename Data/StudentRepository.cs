using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using tp4.Data;
using tp4.Models;

namespace TP4.Data
{
    public interface IStudentRepository<T> where T : class
    {
        T Get(int id); IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<String> GetCourses();
    }
    public class StudentRepository : IStudentRepository<Student>
    {
        private readonly UniversityContext universityContext;
        public StudentRepository(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }

        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            try
            {
                return universityContext.Set<Student>().Where(predicate);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Student Get(int id)
        {
            try
            {

                return universityContext.Set<Student>().Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return universityContext.Set<Student>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<String> GetCourses()
        {
            return universityContext
                .Student.Select(s => s.course).Distinct().ToList();
        }
    }
}
