using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Games_Rental_MVC.Data;
using Games_Rental_MVC.Models;
using Games_Rental_MVC.Repositories;

namespace Games_Rental_MVC.Controllers
{
    public class MembersController : Controller
    {
        //private readonly GamesDbContext _context;
        private readonly IRepository<Members, int, string, string> _memberRepo;

        public MembersController(IRepository<Members, int, string, string> memberRepo)
        {
            _memberRepo = memberRepo;
        }

        // GET: Members
        public async Task<IActionResult> Index(string SearchMember = "", string SearchGame = "")
        {
            var context = await _memberRepo.GetAll(SearchMember, SearchGame);
            return View(context);

            
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var context = await _memberRepo.GetById(id);
            if (context == null)
            {
                return NotFound();
            }

            return View(context);
        }


        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Adress")] Members members)
        {

            if (ModelState.IsValid)
            {
                await _memberRepo.Insert(members);
                await _memberRepo.Save();
                return RedirectToAction(nameof(Index));
            }
                        
            return View(members);
        }

       
        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var context = await _memberRepo.GetById(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Adress")] Members members)
        {
            await _memberRepo.Update(/*id,*/ members);

            
            return RedirectToAction(nameof(Index));
            
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var context = await _memberRepo.GetById(id);
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

            await _memberRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool MembersExists(int id)
        //{
        //    return _context.Members.Any(e => e.Id == id);
        //}
    }
}


//private readonly GamesDbContext _context;

//public MembersController(GamesDbContext context)
//{
//    _context = context;
//}

//// GET: Members
//public async Task<IActionResult> Index(string SearchText = "")
//{
//    List<Members> members;
//    if (SearchText != "" && SearchText != null)
//    {
//        members = await _context.Members.Where(
//           m => m.Name.Contains(SearchText)).ToListAsync();
//    }
//    else
//    {
//        members = await _context.Members.ToListAsync();

//    }

//    return View(members);
//}

//// GET: Members/Details/5
//public async Task<IActionResult> Details(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var members = await _context.Members
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (members == null)
//    {
//        return NotFound();
//    }

//    return View(members);
//}

//// GET: Members/Create
//public IActionResult Create()
//{
//    return View();
//}

//// POST: Members/Create
//// To protect from overposting attacks, enable the specific properties you want to bind to, for 
//// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Create([Bind("Id,Name,Email,Adress")] Members members)
//{
//    if (ModelState.IsValid)
//    {
//        _context.Add(members);
//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }
//    return View(members);
//}

//// GET: Members/Edit/5
//public async Task<IActionResult> Edit(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var members = await _context.Members.FindAsync(id);
//    if (members == null)
//    {
//        return NotFound();
//    }
//    return View(members);
//}

//// POST: Members/Edit/5
//// To protect from overposting attacks, enable the specific properties you want to bind to, for 
//// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Adress")] Members members)
//{
//    if (id != members.Id)
//    {
//        return NotFound();
//    }

//    if (ModelState.IsValid)
//    {
//        try
//        {
//            _context.Update(members);
//            await _context.SaveChangesAsync();
//        }
//        catch (DbUpdateConcurrencyException)
//        {
//            if (!MembersExists(members.Id))
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
//    return View(members);
//}

//// GET: Members/Delete/5
//public async Task<IActionResult> Delete(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }

//    var members = await _context.Members
//        .FirstOrDefaultAsync(m => m.Id == id);
//    if (members == null)
//    {
//        return NotFound();
//    }

//    return View(members);
//}

//// POST: Members/Delete/5
//[HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public async Task<IActionResult> DeleteConfirmed(int id)
//{
//    var members = await _context.Members.FindAsync(id);
//    _context.Members.Remove(members);
//    await _context.SaveChangesAsync();
//    return RedirectToAction(nameof(Index));
//}

//private bool MembersExists(int id)
//{
//    return _context.Members.Any(e => e.Id == id);
//}
