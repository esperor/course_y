using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace course.Server.Data
{
    [Table("InsuranceCases")]
    public class InsuranceCase
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(TypeID))]
        public InsuranceType InsuranceType { get; set; }
        public int TypeID { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int AnnualCost { get; set; }
    }
}
