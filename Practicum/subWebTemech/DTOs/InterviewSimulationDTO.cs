namespace subWebTemech.DTOs
{
    public class InterviewSimulationDTO
    {
        public int InterviewSimulationID { get; set; }
        public DateTime InterviewSimulationDate { get; set; }
        public int UserID { get; set; }
        public List<QuestionSimulationDTO> Questions { get; set; }

    }

}
