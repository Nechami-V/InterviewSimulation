using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace subWebTemech.Models
{
    public class QuestionSimulation
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int QuestionSimulationID { get; set; }
        public string QuestionText { get; set; }
        public string? Hint { get; set; }
    }
}
