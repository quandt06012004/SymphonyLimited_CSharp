using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("Class")]
    public partial class Class
    {
        [Key]
        public int ClassID { get; set; }

        [Column("class_name")]
        public string ClassName { get; set; } = null!;

        [Column("course_id")]
        public int CourseID { get; set; }

        [Column("faculty_id")]
        public int FacultyID { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        public string Location { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;
        public virtual Faculty Faculty { get; set; } = null!;
        public virtual ICollection<LabSession> LabSessions { get; set; } = new List<LabSession>();
        public virtual ICollection<StudentCourseRegistration> Registrations { get; set; } = new List<StudentCourseRegistration>();
    }
}
