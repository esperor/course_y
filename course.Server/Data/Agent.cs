using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace course.Server.Data
{
    [Table("Agents")]
    public class Agent
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateOnly DateHired { get; set; }

        [Required]
        public string Passport { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
