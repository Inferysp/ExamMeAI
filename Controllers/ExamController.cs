using ExamMeAI.Data;
using ExamMeAI.Demo.OpenAI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExamMeAI.Controllers
{
    [Authorize]
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
            var questions = _context.Questions.ToList();
            return View(questions);
        }

        [HttpPost]
        public IActionResult GetQuestionDetails(int selectedID)
        {
            var selectedQuestion = _context.Questions.FirstOrDefault(q => q.ID == selectedID);

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

            return NotFound();
        }

        [HttpPost]
        public IActionResult ExaminAIButtonToggle([FromBody] int questionID)
        {
            //var coto = _context.UserActivity.Where(e => e.QuestionId == questionID).FirstOrDefault();
            //if (coto.IsExaminedByAI == true)
            //    return Json(new { isExaminedByAI = false });

            //Test only
            if (questionID != null)
                return Json(new { isExaminedByAI = false });

            return Json(new { isExaminedByAI = true });
        }

        public async Task<IActionResult> GetQuestions()
        {
            var questions = _context.Questions.ToList();
            return PartialView("ExamMe", questions);
        }

        [HttpPost]
        public IActionResult GetAssessment(String answer, String question)
        {
            return Content("answer: " + answer + " question: " + question);
        }

    }
}
