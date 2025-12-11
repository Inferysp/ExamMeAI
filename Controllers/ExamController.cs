using ExamMeAI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExamMeAI.Controllers
{
    public class ExamController : Controller
    {
        private readonly ExamMeAiContext _context;

        public ExamController(ExamMeAiContext context)
        {
            _context = context;
        }

        public IActionResult ExamMeAI()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var questions = _context.Question.ToList();
            return View(questions);
        }

        // Akcja POST (obsługuje wybór z DropDown)
        [HttpPost]
        public IActionResult Index(int selectedQuestionId)
        {
            // 1. Znajdź pełny tekst pytania w bazie danych na podstawie otrzymanego ID
            var selectedQuestion = _context.Question.FirstOrDefault(q => q.QuestionId == selectedQuestionId);

            if (selectedQuestion != null)
            {
                // 2. Przekaż tekst pytania do ViewBag, aby był dostępny w widoku
                ViewBag.SelectedQuestionText = selectedQuestion.QuestionText;
                ViewBag.SelectedQuestionId = selectedQuestion.QuestionId; // Opcjonalnie: zachowaj ID
            }

            // 3. Przeładuj listę pytań, aby ponownie wypełnić DropDown na wypadek kolejnego wyboru
            var questions = _context.Question.ToList();
            return View(questions);
        }

        // Akcja zwracająca listę pytań     
        public IActionResult GetQuestions()
        {
            var questions = _context.Question.ToList();
            return PartialView("ExamMe", questions);
        }
    }
}
