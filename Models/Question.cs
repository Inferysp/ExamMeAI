using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamMeAI.Models
{
    public class Question
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Treść pytania jest wymagana")]
        [Display(Name = "Treść pytania")]
        public string QuestionText { get; set; } = null!;
        public string? User { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [Display(Name = "Tytuł")]
        public int TitleID { get; set; }

        [ValidateNever]
        public Title Title { get; set; } = null!;

        [Required(ErrorMessage = "Dziedzina jest wymagana")]
        [Display(Name = "Dziedzina")]
        public int DomainID { get; set; }

        [ValidateNever]
        public Domain Domain { get; set; } = null!;
    }
}
