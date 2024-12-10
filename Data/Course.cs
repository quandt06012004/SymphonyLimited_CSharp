using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Column("course_name")]
        public string CourseName { get; set; } = null!;

        [Column("duration_months")]
        public int DurationMonths { get; set; }

        public decimal Fee { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
        public virtual ICollection<StudentCourseRegistration> Registrations { get; set; } = new List<StudentCourseRegistration>();
    }
}
