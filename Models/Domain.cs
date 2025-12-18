using System.ComponentModel.DataAnnotations;

namespace ExamMeAI.Models
{
    public class Domain
    {
        public int ID { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<Question> Questions { get; set; } = null!;

    }
}
