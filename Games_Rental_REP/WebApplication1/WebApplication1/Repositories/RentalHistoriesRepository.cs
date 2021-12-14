using Games_Rental_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games_Rental_MVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Games_Rental_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace Games_Rental_MVC.Repositories
{
    public class RentalHistoriesRepository : IRepository<RentalHistories, int, string, string>
    {
        private readonly GamesDbContext _context;

        public RentalHistoriesRepository(GamesDbContext context)
        {
            _context = context;
        }

       

        public async Task<IEnumerable<RentalHistories>> GetAll(String SearchMember, string SearchGame)
        {
            List<RentalHistories> histories;
            if (SearchMember != "" && SearchMember != null)
            {

                histories = await _context.RentalHistories.Where(
                   m => m.MemberId.ToString().Contains(SearchMember)).ToListAsync();
            }
            else if (SearchGame != "" && SearchGame != null)
            {              
                       

                histories = await _context.RentalHistories.Where(
                   m => m.GameId.ToString().Contains(SearchGame)).ToListAsync();
            }
            else
            {
                histories = await _context.RentalHistories.ToListAsync();
               
            }
            return histories;
        }

        
        public async Task<RentalHistories> GetById(int id)
        {

            return await _context.RentalHistories.Include(r => r.Member).FirstOrDefaultAsync(z => z.Id == id);                                

        }

        public async Task<RentalHistories> Insert(RentalHistories Entity)
        {
            await _context.AddAsync(Entity);
            await _context.SaveChangesAsync();

            return Entity;
        }

        //// POST: RentalHistories/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,RentalDate,GameId,MemberId")] RentalHistories rentalHistories)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(rentalHistories);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", rentalHistories.MemberId);
        //    return View(rentalHistories);
        //}


        public async Task Delete(int id)
        {
            var rentalhist = await _context.RentalHistories.FirstOrDefaultAsync(z => z.Id == id);
            if(rentalhist != null)
            {
                _context.Remove(rentalhist);
                //await _context.SaveChangesAsync();
            }
        }

      


        public async Task Update(/*int id,*/ RentalHistories Entity)
        {
            _context.Update(Entity);
            await _context.SaveChangesAsync();
            //return Entity;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }







        //public async Task<RentalHistories> Index(string SearchText = "")
        //{

        //    if (SearchText != "" && SearchText != null)
        //    {

        //       return histories = await _context.RentalHistories.Where(
        //           m => m.GameId.ToString().Contains(SearchText)).ToListAsync();

        //    }
        //    else
        //    {
        //        var histories = await _context.RentalHistories.ToListAsync();
        //        return histories;

        //    }



        //}

        //// GET: RentalHistories/Details/5
        //public async Task<RentalHistories> Details(int? id)
        //{

        //    var rentalHistories = await _context.RentalHistories
        //        .Include(r => r.Member)
        //        .FirstOrDefaultAsync(m => m.Id == id);


        //    return rentalHistories;
        //}

        //// GET: RentalHistories/Create
        //public Task<IActionResult> Create()
        //{
        //    ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
        //    return View();
        //}

        //// POST: RentalHistories/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,RentalDate,GameId,MemberId")] RentalHistories rentalHistories)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(rentalHistories);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", rentalHistories.MemberId);
        //    return View(rentalHistories);
        //}


        //// GET: RentalHistories/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rentalHistories = await _context.RentalHistories.FindAsync(id);
        //    if (rentalHistories == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", rentalHistories.MemberId);
        //    return View(rentalHistories);
        //}



        //// POST: RentalHistories/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,RentalDate,GameId,MemberId")] RentalHistories rentalHistories)
        //{
        //    if (id != rentalHistories.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(rentalHistories);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RentalHistoriesExists(rentalHistories.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", rentalHistories.MemberId);
        //    return View(rentalHistories);
        //}

        //// GET: RentalHistories/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rentalHistories = await _context.RentalHistories
        //        .Include(r => r.Member)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (rentalHistories == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rentalHistories);
        //}

        //// POST: RentalHistories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var rentalHistories = await _context.RentalHistories.FindAsync(id);
        //    _context.RentalHistories.Remove(rentalHistories);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RentalHistoriesExists(int id)
        //{
        //    return _context.RentalHistories.Any(e => e.Id == id);
        //}


    }
}
