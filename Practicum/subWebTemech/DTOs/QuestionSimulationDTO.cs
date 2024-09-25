namespace subWebTemech.DTOs
{
    public class QuestionSimulationDTO
    {
        public int QuestionSimulationID { get; set; }
        public string QuestionText { get; set; }
        public string Hint { get; set; }
        public AnswerSimulationDTO Answer { get; set; }

    }
}
