using Games_Rental_MVC.Data;
using Games_Rental_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games_Rental_MVC.Repositories
{
    public class GamesRepository 
    {
        private readonly GamesDbContext context;
        public GamesRepository(GamesDbContext context) => this.context = context;


        public async Task<IEnumerable<Games>> GetAll(string SearchText)
        {
            List<Games> games;
            if (SearchText != "" && SearchText != null)
            {
                games = await context.Games.Where(
                   m => m.Name.Contains(SearchText)).Include(b => b.Id)
                                        .Include(a => a.Name)
                                        .Include(c => c.Payment)
                                        .Include(d => d.RentalDates)
                                        .Include(e => e.IsAvailable)
                                        .Include(f => f.RentalHistory)
                                        .Include(g => g.RentalHistoryId)
                                        .ToListAsync();
                
            }
            else
            {
                games = await context.Games.Include(b => b.Id)
                                        .Include(a => a.Name)
                                        .Include(c => c.Payment)
                                        .Include(d => d.RentalDates)
                                        .Include(e => e.IsAvailable)
                                        .Include(f => f.RentalHistory)
                                        .Include(g => g.RentalHistoryId)
                                        .ToListAsync();
                

            }

            return games;
        }

        public async Task<Games> GetById(int id)
        {
            return await context.Games.FindAsync(id);
        }

        public async Task<Games> Insert(Games entity)
        {
            await context.Games.AddAsync(entity);
            return entity;
        }
        public async Task Delete(int id)
        {
            var games = await context.Games.FirstOrDefaultAsync(h => h.Id == id);
            if (games != null)
            {
                context.Remove(games);
            }

        }
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

    }
}
