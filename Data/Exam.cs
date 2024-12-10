using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }

        [Column("exam_date")]
        public DateTime ExamDate { get; set; }

        [Column("exam_fee")]
        public decimal ExamFee { get; set; }

        [Column("max_marks")]
        public int MaxMarks { get; set; }

        [Column("available_courses")]
        public string? AvailableCourses { get; set; }

        public virtual ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
