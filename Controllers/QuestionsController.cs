using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamMeAI.Data;
using ExamMeAI.Models;
using ExamMeAI.Models.CombiningModels;

namespace ExamMeAI.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ExamMeAiContext _context;

        public QuestionsController(ExamMeAiContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var qList = await _context.Question
                .Select(c => new QuestionList
                {
                    ID = c.ID,
                    QuestionText = c.QuestionText,
                    TitleText = c.Title.TitleText,
                    DomainName = c.Domain.Name,
                })
                .ToListAsync();

            return View(qList);
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .Include(q => q.Title)
                .Include(a => a.Domain)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            //Przekazanie listy tytułów do widoku
            ViewData["TitleID"] = new SelectList(_context.Title, "ID", "TitleText");
            ViewData["DomainID"] = new SelectList(_context.Domain, "ID", "Name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,QuestionText,User,TitleID,DomainID")] Question question)
        {

            // SPRAWDŹ CZY TitleID ISTNIEJE W BAZIE
            bool titleExists = await _context.Title.AnyAsync(t => t.ID == question.TitleID);
            if (!titleExists)
            {
                ModelState.AddModelError("TitleID", "Wybrany tytuł nie istnieje.");
            }

            // SPRAWDŹ CZY DomainID ISTNIEJE
            bool domainExists = await _context.Domain.AnyAsync(d => d.ID == question.DomainID);
            if (!domainExists)
            {
                ModelState.AddModelError("DomainID", "Wybrana domena nie istnieje.");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(question);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Pytanie zostało dodane.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"Error: {error.ErrorMessage}");
                    }

                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", $"Błąd zapisu: {ex.InnerException?.Message ?? ex.Message}");
            }
            // Debug: zbierz błędy walidacji (zastąp Console lub TempData własnym loggerem)
            //var errors = ModelState
            //    .Where(kvp => kvp.Value.Errors.Count > 0)
            //    .Select(kvp => new { Key = kvp.Key, Errors = kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray() })
            //    .ToList();
            //TempData["ModelErrors"] = System.Text.Json.JsonSerializer.Serialize(errors);

            ViewData["TitleID"] = new SelectList(_context.Title, "ID", "TitleText", question.TitleID);
            ViewData["DomainID"] = new SelectList(_context.Domain, "ID", "Name", question.DomainID);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,text,User,Title")] Question question)
        {
            if (id != question.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.FindAsync(id);
            if (question != null)
            {
                _context.Question.Remove(question);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.ID == id);
        }
    }
}
