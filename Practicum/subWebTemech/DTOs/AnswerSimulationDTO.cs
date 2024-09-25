namespace subWebTemech.DTOs
{
    public class AnswerSimulationDTO
    {
        public int AnswerSimulationID { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public string Links { get; set; }
        public QuestionSimulationDTO Question { get; internal set; }
    }
}
