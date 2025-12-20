using ExamMeAI.Data;
using ExamMeAI.Demo.OpenAI;
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

        // Nowa akcja POST dedykowana dla AJAX. Zwraca dane JSON.
        [HttpPost]
        public IActionResult GetQuestionDetails(int questionId)
        {
            var selectedQuestion = _context.Question.FirstOrDefault(q => q.ID == questionId);

            if (selectedQuestion != null)
            {
                // Zwróć obiekt anonimowy w formacie JSON
                return Json(new
                {
                    questionId = selectedQuestion.ID,
                    questionText = selectedQuestion.QuestionText
                });
            }

            // Zwróć błąd 404 lub pusty wynik, jeśli nie znaleziono pytania
            return NotFound();
        }

        // Akcja zwracająca listę pytań     
        public IActionResult GetQuestions()
        {
            var questions = _context.Question.ToList();
            return PartialView("ExamMe", questions);
        }

        public IActionResult GetAssessment()
        {
            string v = "";
            //if (_config.GetConnectionString("OpenAIKey") != null)
            //{
            //    var question = "q";
            //    var answer = "a";

            //    v = ChatOpenAI.GetInstance().RunAiTest(_config.GetConnectionString("OpenAIKey"), question, answer);
            //}

            return Content("Testowy message!");
        }

    }
}
