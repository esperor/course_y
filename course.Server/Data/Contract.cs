using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace course.Server.Data
{
    [Table("Contracts")]
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Agent))]
        public int AgentId { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [ForeignKey(nameof(InsuranceCase))]
        public int InsuranceCaseId { get; set; }

        [Required]
        public DateOnly ContractSignedDate { get; set; }

        [Required] // years
        public int ValidityTerm { get; set; }
    }
}
