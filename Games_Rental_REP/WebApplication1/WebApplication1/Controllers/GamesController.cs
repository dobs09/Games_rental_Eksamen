using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Games_Rental_MVC.Data;
using Games_Rental_MVC.Models;

namespace Games_Rental_MVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly GamesDbContext _context;

        public GamesController(GamesDbContext context)
        {
            _context = context;
        }

        // GET: Games
        //public async Task<IActionResult> Index()
        //{
        //    var gamesDbContext = _context.Games.Include(g => g.RentalHistory);
        //    return View(await gamesDbContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(string SearchText = "")
        {
            List<Games> games;
            if (SearchText != "" && SearchText != null)
            {
                games = await _context.Games.Where(
                   m => m.Name.Contains(SearchText)).ToListAsync();
            }
            else
            {
                games = await _context.Games.ToListAsync();

            }

            return View(games);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .Include(g => g.RentalHistory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            ViewData["RentalHistoryId"] = new SelectList(_context.RentalHistories, "Id", "Id");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Payment,Name,RentalDates,IsAvailable,RentalHistoryId")] Games games)
        {
            if (ModelState.IsValid)
            {
                _context.Add(games);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RentalHistoryId"] = new SelectList(_context.RentalHistories, "Id", "Id", games.RentalHistoryId);
            return View(games);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games.FindAsync(id);
            if (games == null)
            {
                return NotFound();
            }
            ViewData["RentalHistoryId"] = new SelectList(_context.RentalHistories, "Id", "Id", games.RentalHistoryId);
            return View(games);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Payment,Name,RentalDates,IsAvailable,RentalHistoryId")] Games games)
        {
            if (id != games.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(games);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesExists(games.Id))
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
            ViewData["RentalHistoryId"] = new SelectList(_context.RentalHistories, "Id", "Id", games.RentalHistoryId);
            return View(games);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .Include(g => g.RentalHistory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var games = await _context.Games.FindAsync(id);
            _context.Games.Remove(games);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GamesExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
