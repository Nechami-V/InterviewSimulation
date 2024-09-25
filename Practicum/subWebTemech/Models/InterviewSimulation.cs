using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace subWebTemech.Models
{
    public class InterviewSimulation
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int InterviewSimulationID { get; set; }
            public DateTime InterviewSimulationDate { get; set; }
            public int UserID { get; set; }
            public virtual User User { get; set; }
            public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }

    }
}

