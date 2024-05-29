using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace course.Server.Data
{
    [Table("Contracts")]
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; }
        public int AgentId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        public int ClientId { get; set; }
        

        [ForeignKey(nameof(InsuranceCaseId))]
        public InsuranceCase InsuranceCase { get; set; }
        public int InsuranceCaseId { get; set; }

        [Required]
        public DateOnly ContractSignedDate { get; set; }

        [Required] // years
        public int ValidityTerm { get; set; }
    }
}
