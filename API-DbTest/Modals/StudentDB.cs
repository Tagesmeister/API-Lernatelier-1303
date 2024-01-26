using Microsoft.EntityFrameworkCore;

namespace API_DbTest.Modals
{
    public class StudentDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentDB(DbContextOptions<StudentDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.ID);
        }

    }

}
