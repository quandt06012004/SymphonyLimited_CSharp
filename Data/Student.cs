using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("Student")]
    public class Student
    {
        [Key]   
        public int StudentID { get; set; }

        [Column("first_name")]
        [StringLength(250)]
        public string FirstName { get; set; } = null!;

        [Column("last_name")]
        [StringLength(250)]
        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("entrance_exam_date")]
        public DateTime? EntranceExamDate { get; set; }

        [Column("entrance_exam_fee")]
        public decimal? EntranceExamFee { get; set; }

        [Column("registration_date")]
        public DateTime? RegistrationDate { get; set; }

        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
        public virtual ICollection<StudentCourseRegistration> Registrations { get; set; } = new List<StudentCourseRegistration>();
        public virtual ICollection<LabSession> LabSessions { get; set; } = new List<LabSession>();
    }
}
