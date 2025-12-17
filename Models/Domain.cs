using System.ComponentModel.DataAnnotations;

namespace ExamMeAI.Models
{
    public class Domain
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
