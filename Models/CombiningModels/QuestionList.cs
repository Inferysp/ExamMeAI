
namespace ExamMeAI.Models.CombiningModels
{
    public class QuestionList
    {
        public int ID { get; set; }
        public string QuestionText { get; set; } = null!;

        public string TitleText { get; set; } = null!;

        public string DomainName { get; set; } = null!;
    }
}
