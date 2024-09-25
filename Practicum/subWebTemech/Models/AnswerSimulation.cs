using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace subWebTemech.Models
{
    public class AnswerSimulation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerSimulationID { get; set; }
        public string? AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public string? Links { get; set; } 
    }

}
