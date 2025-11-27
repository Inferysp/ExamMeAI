namespace ExamMeAI.Models
{
    public class Question
    {

        public int Id { get; set; }
        public string text { get; set; }    
        public string User { get; set; }
        public string Title { get; set; }

        public Genre genre_id { get; set; }

        public Domain domain_id { get; set; }
    }
}
