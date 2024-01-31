using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using suggestionbox.Data;
using suggestionbox.Models;

namespace suggestionbox.Controllers
{
    public class SuggestionsController : Controller
    {
        private readonly suggestionboxContext _context;

        public SuggestionsController(suggestionboxContext context)
        {
            _context = context;
        }

        // GET: Suggestions
        public async Task<IActionResult> Index()
        {
            var list = await _context.Suggestion.Where(a => a.deleted_At == null).ToListAsync();
            foreach(var item in list)
            {
                var f = 1;
            }
            return View(list);
        }

        // GET: Suggestions/Create
        public async Task<IActionResult> Create()
        {
            var list = await _context.SuggestionType.ToListAsync();
            ViewData["typelist"] = list.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.name,
                    Value = a.id.ToString(),
                    Selected = false
                };
            });

            return View();
        }

        //TODO  This is obviously not the way to go. The frontend is currently sending the data in a different way from plain JSON, causing arguements to not bind corretly.
        //      The current workaround is making two functions calling the same functionality. This needs to be fixed.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("id,subject,description,userId,userName,suggestionTypeId,startDate,endDate,categories")] Suggestion suggestion)
        {
            return await createSuggestion(suggestion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDup([FromBody] Suggestion suggestion)
        {
            return await createSuggestion(suggestion);
        }

        private async Task<IActionResult> createSuggestion(Suggestion suggestion)
        {
            suggestion.suggestionType = _context.SuggestionType.FirstOrDefault(a => a.id == suggestion.suggestionTypeId);

            if (ModelState.IsValid)
            {
                _context.Add(suggestion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Suggestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suggestion = await _context.Suggestion
                .FirstOrDefaultAsync(m => m.id == id);
            if (suggestion == null)
            {
                return NotFound();
            }

            return View(suggestion);
        }

        // POST: Suggestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suggestion = await _context.Suggestion.FindAsync(id);
            if (suggestion != null)
            {
                suggestion.deleted_At = DateTime.Now;
                _context.Suggestion.Update(suggestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuggestionExists(int id)
        {
            return _context.Suggestion.Any(e => e.id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
