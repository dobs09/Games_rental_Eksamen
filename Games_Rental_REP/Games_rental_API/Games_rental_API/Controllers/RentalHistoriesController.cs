using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Games_rental_API.Context;
using Games_rental_API.Models;
using Games_rental_API.Classes;

namespace Games_rental_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalHistoriesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public RentalHistoriesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/RentalHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalHistory>>> GetrentalHistories([FromQuery] QueryParameters parameters)
        {
            IQueryable<RentalHistory> histories = _context.rentalHistories;
            //IQueryable<Game> games = _context.games;
                       
            if (!String.IsNullOrEmpty(parameters.MemberName))
            {
                
                histories = histories.Where(
                    n => n.Members.Name.ToLower().Contains(parameters.MemberName));
            }

            if (!String.IsNullOrEmpty(parameters.GameName))
            {
                histories = histories.Where(
                    m => m.Games.Name.ToLower().Contains(parameters.GameName));
            }
            if (!String.IsNullOrEmpty(parameters.Sort))
            {
                if(parameters.Sort == "desc")
                {
                    histories.OrderByDescending(x => x.ID);
                }
                else
                {
                    histories.OrderBy(x => x.ID);
                }
            }

            return Ok(await histories.ToArrayAsync());
        }

        // GET: api/RentalHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentalHistory>> GetRentalHistory(int id)
        {
            var rentalHistory = await _context.rentalHistories.FindAsync(id);

            if (rentalHistory == null)
            {
                return NotFound();
            }

            return rentalHistory;
        }

        // PUT: api/RentalHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentalHistory(int id, RentalHistory rentalHistory)
        {
            if (id != rentalHistory.ID)
            {
                return BadRequest();
            }

            _context.Entry(rentalHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalHistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RentalHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RentalHistory>> PostRentalHistory(RentalHistory rentalHistory)
        {
            _context.rentalHistories.Add(rentalHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentalHistory", new { id = rentalHistory.ID }, rentalHistory);
        }

        // DELETE: api/RentalHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentalHistory>> DeleteRentalHistory(int id)
        {
            var rentalHistory = await _context.rentalHistories.FindAsync(id);
            if (rentalHistory == null)
            {
                return NotFound();
            }

            _context.rentalHistories.Remove(rentalHistory);
            await _context.SaveChangesAsync();

            return rentalHistory;
        }

        private bool RentalHistoryExists(int id)
        {
            return _context.rentalHistories.Any(e => e.ID == id);
        }
    }
}
