using Microsoft.EntityFrameworkCore;

namespace Data_DAL.Data
{
    public class DataContext : DbContext

    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<LabSession> LabSessions { get; set; }

        public DbSet<FAQs> FAQs { get; set; }

        public DbSet<Payments> Payments { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<StudentCourseRegistration> StudentCourseRegistrations { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define constraints if necessary
            modelBuilder.Entity<LabSession>()
                .HasCheckConstraint("chk_SessionType", "[SessionType] IN ('DuringCourse', 'AfterCourse')");

            // Define relationships
            modelBuilder.Entity<StudentCourseRegistration>()
                .HasOne(scr => scr.Student)
                .WithMany(s => s.Registrations)
                .HasForeignKey(scr => scr.StudentID)
                .OnDelete(DeleteBehavior.Restrict); // Hoặc DeleteBehavior.NoAction

            modelBuilder.Entity<StudentCourseRegistration>()
                .HasOne(scr => scr.Course)
                .WithMany(c => c.Registrations)
                .HasForeignKey(scr => scr.CourseID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourseRegistration>()
                .HasOne(scr => scr.Class)
                .WithMany(c => c.Registrations)
                .HasForeignKey(scr => scr.ClassID)
                .OnDelete(DeleteBehavior.Restrict);

            // Đảm bảo rằng cascade delete không được phép giữa các bảng
            /* modelBuilder.Entity<StudentCourseRegistration>()
                 .HasOne(s => s.Student)
                 .WithMany()
                 .OnDelete(DeleteBehavior.NoAction);*/  // Không thực hiện cascade delete cho Student

            /*  modelBuilder.Entity<StudentCourseRegistration>()
                  .HasOne(s => s.Course)
                  .WithMany()
                  .OnDelete(DeleteBehavior.NoAction);*/  // Không thực hiện cascade delete cho Course

            /*  modelBuilder.Entity<StudentCourseRegistration>()
                  .HasOne(s => s.Class)
                  .WithMany()
                  .OnDelete(DeleteBehavior.NoAction);  // Không thực hiện cascade delete cho Class*/
        }

    }
}
