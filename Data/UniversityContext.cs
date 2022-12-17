using Microsoft.EntityFrameworkCore;
using tp4.Models;

namespace tp4.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        static public int c = 0;
        private static UniversityContext instance = null;
        public UniversityContext(DbContextOptions o) : base(o) {
            c++;
        }
        static public UniversityContext Instantiate_UniversityContext()
        {   
            if(instance == null)
            {
                var optionBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionBuilder.UseSqlite($"Data Source=C:\\Users\\heha\\OneDrive\\Desktop\\GL3\\tp4.db");
                instance = new UniversityContext(optionBuilder.Options);
            }

            return instance;
        }
    }
}
