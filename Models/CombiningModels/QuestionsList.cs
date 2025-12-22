
namespace ExamMeAI.Models.CombiningModels
{
    public class QuestionsList
    {
        public int ID { get; set; }
        public string QuestionText { get; set; } = null!;

        public string TitleText { get; set; } = null!;

        public string DomainName { get; set; } = null!;
    }
}
