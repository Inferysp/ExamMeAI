namespace ExamMeAI.Models
{
    public class Domain
    {
        public int DomainId { get; set; }

        public string DomainName { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Title> Titles { get; set; }
    }
}
