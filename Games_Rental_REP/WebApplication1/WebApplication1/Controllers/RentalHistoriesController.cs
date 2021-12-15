using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Games_Rental_MVC.Controllers;
using Games_Rental_MVC.Data;
using Games_Rental_MVC.Models;
using Games_Rental_MVC.Repositories;

namespace Games_Rental_MVC.Controllers
{
    public class RentalHistoriesController : Controller
    {
        //private readonly GamesDbContext _context;
        
        private readonly IRepository<RentalHistories, int, string, string> _rentalhistoriesRepo;


        public RentalHistoriesController( IRepository<RentalHistories, int, string, string> rentalhistoriesRepo)
        {
           
            _rentalhistoriesRepo = rentalhistoriesRepo;


        }

        public async Task<IActionResult> Index(string SearchGame = "", string SearchMember = "")
        {
            var context = await _rentalhistoriesRepo.GetAll(SearchGame, SearchMember);
            return View(context);
           
        }

        
        // GET: RentalHistories/Details/5
        public async Task<IActionResult> Details(int id)
        {
           

            var context = await _rentalhistoriesRepo.GetById(id);
            if (context == null)
            {
                return NotFound();
            }

            return View(context);
        }

        
        // GET: RentalHistories/Create
        public IActionResult Create()
        {
            //ViewData["MemberId"] = new SelectList(_rentalhistoriesRepo. .Members, "Id", "Id");
            return View();
        }

        // POST: RentalHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RentalDate,GameId,MemberId")] RentalHistories rentalHistories)
        {
            if (ModelState.IsValid)
            {
                var context = await _rentalhistoriesRepo.Insert(rentalHistories);

                return RedirectToAction(nameof(Index));
            }
            return View(rentalHistories);
        }
        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var context = await _rentalhistoriesRepo.GetById(id);
            if (context == null)
            {
                return NotFound();
            }

            return View(context);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var members = await _context.Members.FindAsync(id);
            //_context.Members.Remove(members);
            //await _context.SaveChangesAsync();

            await _rentalhistoriesRepo.Delete(id);
            await _rentalhistoriesRepo.Save();
            return RedirectToAction(nameof(Index));
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var context = await _rentalhistoriesRepo.GetById(id);
            if (context == null)
            {
                return NotFound();
            }

            return View(context);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Adress")] RentalHistories rental)
        {
            await _rentalhistoriesRepo.Update(/*id,*/ rental);


            return RedirectToAction(nameof(Index));

        }

    }
}
