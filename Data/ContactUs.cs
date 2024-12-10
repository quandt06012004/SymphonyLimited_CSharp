using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("ContactUs")]
    public class ContactUs
    {
        [Key]
        public int ContactID { get; set; }

        public string BranchName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
