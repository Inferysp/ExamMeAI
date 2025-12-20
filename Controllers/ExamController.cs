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
        public async Task<IActionResult> GetQuestions()
        {
            var questions = _context.Question.ToList();
            return PartialView("ExamMe", questions);
        }
        // Nowa akcja POST dedykowana dla AJAX. Zwraca dane string.
        [HttpPost]
        public IActionResult GetAssessment(String answer, String question)
        {
            return Content("answer: " + answer + " question: " + question);
        }

        // Nowa akcja POST dedykowana dla AJAX. Zwraca dane string.
        [HttpPost]
        public IActionResult GetAssessment1(String answer, String question)
        {
            //string v = "";
            //if (_config.GetConnectionString("OpenAIKey") != null)
            //{
            //string question = question;
            //var answer = answer;

            //    v = ChatOpenAI.GetInstance().RunAiTest(_config.GetConnectionString("OpenAIKey"), question, answer);
            //}

            return Content("answer: " + answer + " question: " + question);
            //return Content("Testowy message!");
        }
    }
}
