using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_DAL
{
    [Table("FAQs")]
    public class FAQs
    {
        [Key]
        public int FAQID { get; set; }

        public string Question { get; set; } = null!;

        public string Answer { get; set; } = null!;
    }
}
