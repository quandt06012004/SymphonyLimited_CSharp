using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("Faculty")]
    public class Faculty
    {
        
            [Key]
            public int FacultyID { get; set; }

            [Column("first_name")]
            public string FirstName { get; set; } = null!;

            [Column("last_name")]
            public string LastName { get; set; } = null!;

            public string? Email { get; set; }

            public string? Phone { get; set; }

            public string? Department { get; set; }

            public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
            public virtual ICollection<LabSession> LabSessions { get; set; } = new List<LabSession>();
        }
}
