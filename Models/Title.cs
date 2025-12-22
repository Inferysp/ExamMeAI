namespace ExamMeAI.Models
{
    public class Title
    {

        public int ID { get; set; }

        public string TitleText { get; set; } = null!;

        public ICollection<Questions> Questions { get; set; } = new List<Questions>();
    }
}
