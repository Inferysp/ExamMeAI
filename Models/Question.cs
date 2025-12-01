namespace ExamMeAI.Models
{
    public class Question
    {

        public int Id { get; set; }
        public string Text { get; set; }    
        public string? User { get; set; }
        public string? Title { get; set; }

        public Genre Genre_id { get; set; }

        public Domain Domain_id { get; set; }
    }
}
