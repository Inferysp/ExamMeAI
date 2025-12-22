using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ExamMeAI.Models
{
    public class Domain
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Questions> Questions { get; set; } = new List<Questions>();

    }
}
