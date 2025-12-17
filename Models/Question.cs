namespace ExamMeAI.Models
{
    public class Question
    {

        public int ID { get; set; }
        public string QuestionText { get; set; }    
        public string? User { get; set; }

        public int TitleID { get; set; }
        public Title Title { get; set; }

        public int DomainID { get; set; }
        public Domain Domain { get; set; }
    }
}
