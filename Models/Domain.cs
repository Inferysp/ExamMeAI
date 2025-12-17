namespace ExamMeAI.Models
{
    public class Domain
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
