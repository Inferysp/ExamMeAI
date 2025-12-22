using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ExamMeAI.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int QuestionId { get; set; }
        public int examinationId { get; set; }
        public Boolean IsExaminedByAI { get; set; } 
        public DateTime? ActivityDate { get; set; }
        public string? ActivityUserInput { get; set; }

    }
}
