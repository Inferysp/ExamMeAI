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

        public IActionResult ExamMe()
        {
            return View();
        }

        // Akcja zwracająca listę pytań     
        public IActionResult GetQuestions()
        {
            var questions = _context.Question.ToList();
            return PartialView("ExamMe", questions);
        }
    }
}
