using OpenAI.Evals;
using System.ComponentModel.DataAnnotations;

namespace ExamMeAI.Models
{
    public enum Grade
    { A = 1, B = 2, C = 3, D = 4, E = 5, F = 6 }

    public class Exams
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; } = null!;
        public string UserAnswer { get; set; } = null!;
        public string AiEvaluation { get; set; } = null!;

        public string? AiService { get; set; } = null!;
        public string? AiModel { get; set; } = null!;

        public string? ResponseWidthEvaluation { get; set; } = null!;
        public string? RespCorrectnessEvaluation { get; set; }
        public Grade? Grade { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExamDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime ExamTime { get; set; }
    }
}
