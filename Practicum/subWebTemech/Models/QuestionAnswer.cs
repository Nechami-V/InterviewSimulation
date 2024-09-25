using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace subWebTemech.Models
{
    public class QuestionAnswer
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("QuestionSimulationID")]
        public int QuestionSimulationID { get; set; }

        [ForeignKey("AnswerSimulationID")]
        public int AnswerSimulationID { get; set; }

        [ForeignKey("InterviewSimulationID")]
        public int InterviewSimulationID { get; set; }

        public virtual QuestionSimulation QuestionSimulation { get; set; }
        public virtual AnswerSimulation AnswerSimulation { get; set; }
        public virtual InterviewSimulation InterviewSimulation { get; set; }

    }

}

