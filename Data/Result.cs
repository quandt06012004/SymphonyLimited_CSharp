using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("Result")]
    public class Result
    {
        [Key]
        public int ResultID { get; set; }

        [Column("student_id")]
        public int StudentID { get; set; }

        [Column("exam_id")]
        public int ExamID { get; set; }

        [Column("marks_obtained")]
        public int MarksObtained { get; set; }

        [Column("class_assigned")]
        public string ClassAssigned { get; set; } = null!;

        [Column("course_fee")]
        public decimal CourseFee { get; set; }

        [Column("payment_due_date")]
        public DateTime PaymentDueDate { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Exam Exam { get; set; } = null!;
    }
}
