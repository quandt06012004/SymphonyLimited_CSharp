using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data_DAL
{
    [Table("Payments")]
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }

        public int RegistrationID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        [MaxLength(10)]
        public string PaymentMethod { get; set; }

        [MaxLength(10)]
        public string PaymentStatus { get; set; } = "Pending";  // Giá trị mặc định là 'Pending'

        [ForeignKey("RegistrationID")]
        public virtual StudentCourseRegistration Registration { get; set; }
    }
}
