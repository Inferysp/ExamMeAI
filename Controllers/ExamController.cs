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
        public IActionResult GetQuestionDetails(int selectedID)
        {
            var selectedQuestion = _context.Question.FirstOrDefault(q => q.ID == selectedID);

            if (selectedQuestion != null)
            {
                // Zwróć obiekt anonimowy w formacie JSON
                return Json(new
                {
                    questionId = selectedQuestion.ID,
                    questionText = selectedQuestion.QuestionText
                });
            }
            Console.WriteLine($"HttpPost -przetworzono pytanie: {selectedQuestion}");
            // Zwróć błąd 404 lub pusty wynik, jeśli nie znaleziono pytania
            return NotFound();
        }

        // Akcja zwracająca listę pytań ExamMe.cshtml
        public IActionResult GetQuestions()
        {
            var questions = _context.Question.ToList();
            return PartialView("ExamMe", questions);
        }
        // Nowa akcja POST dedykowana dla AJAX. Zwraca dane string.
        [HttpPost]
        public IActionResult GetAssessment()
        {
            //string v = "";
            //if (_config.GetConnectionString("OpenAIKey") != null)
            //{
            //    var question = "q";
            //    var answer = "a";

            //    v = ChatOpenAI.GetInstance().RunAiTest(_config.GetConnectionString("OpenAIKey"), question, answer);
            //}

            //return Content(v);
            return Content("Testowy message!");
        }

    }
}
