using Games_Rental_MVC.Data;
using Games_Rental_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games_Rental_MVC.Repositories
{
    public class MemberRepository : IRepository<Members, int, string, string>
    {
        private readonly GamesDbContext context;
        public MemberRepository(GamesDbContext context) => this.context = context;
        

        public async Task<IEnumerable<Members>> GetAll( string SearchMember = "", string SearchGame ="" )
        {
            List<Members> member;
           
            if (SearchMember != "" && SearchMember != null)
            {

                member = await context.Members.Where(
                   m => m.Name.Contains(SearchMember)).ToListAsync();
            }
            else
            {
                member = await context.Members.ToListAsync();

            }
            return member;
        }

        public async Task<Members> GetById(int id)
        {
            return await context.Members.FirstOrDefaultAsync(z => z.Id == id);

        }

        public async Task<Members> Insert(Members entity)
        {
            await context.AddAsync(entity);

            return entity;
        }
        public async Task Delete(int id)
        {
            
            var member = await context.Members.FirstOrDefaultAsync(c => c.Id == id );
            if(member != null)
            {
                context.Remove(member);
                await context.SaveChangesAsync();
            }

        }

              

        public async Task Save()
        {
             await context.SaveChangesAsync();
        }

        public async Task Update(/*int id,*/ Members Entity)
        {
            context.Update(Entity);
            await context.SaveChangesAsync();
            //return Entity;
        }




        //Task IRepository<Members, int, string, string>.Update(int id, Members Entity)
        //{
        //    throw new NotImplementedException();
        //}


    }
    
}
