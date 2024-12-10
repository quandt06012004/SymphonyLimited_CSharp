using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("StudentCourseRegistration")]
    public class StudentCourseRegistration
    {
        [Key]
        public int RegistrationID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        public int ClassID { get; set; }

        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; }

        public decimal Fee { get; set; }

        [Column("payment_status")]
        public string PaymentStatus { get; set; } = "Pending";

        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
        public virtual Class Class { get; set; } = null!;
    }
}
