namespace ExamMeAI.Models
{
    public class Title
    {

        public int ID { get; set; }

        public string TitleText { get; set; } = null!;

        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
