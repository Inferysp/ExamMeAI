namespace ExamMeAI.Models
{
    public class Title
    {

        public int TitleId { get; set; }

        public string TitleText { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
