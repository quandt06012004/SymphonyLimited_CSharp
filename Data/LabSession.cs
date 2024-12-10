using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("LabSession")]
    public class LabSession
    {
        [Key]
        public int LabSessionID { get; set; }

        [Column("student_id")]
        public int StudentID { get; set; }

        [Column("class_id")]
        public int ClassID { get; set; }

        [Column("session_date")]
        public DateTime SessionDate { get; set; }

        
        public string SessionType { get; set; } = null!;

        public decimal? Fee { get; set; }

        [Column("faculty_id")]
        public int? FacultyID { get; set; }

        public virtual Student Student { get; set; } = null!;
        public virtual Class Class { get; set; } = null!;
        public virtual Faculty? Faculty { get; set; }
    }
}
