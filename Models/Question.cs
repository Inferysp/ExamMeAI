namespace ExamMeAI.Models
{
    public class Question
    {

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }    
        public string? User { get; set; }

        public int TitleId { get; set; }
        public Title Title { get; set; }

        public int DomainId { get; set; }
        public Domain Domain { get; set; }
    }
}
