using Games_rental_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games_rental_API.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalHistory>().HasOne(g => g.Games).WithMany(r => r.History).HasForeignKey(r => r.GameID);
            modelBuilder.Entity<RentalHistory>().HasOne(m => m.Members);
            modelBuilder.Entity<Member>().HasMany(n => n.History).WithOne(o => o.Members).HasForeignKey(o => o.MemberID);



            
            
        }

        public DbSet<RentalHistory> rentalHistories {get; set;}
        public DbSet<Employee> employees { get; set; }
        public DbSet<Game> games { get; set; }
        public DbSet<Member> members { get; set; }

    }
}
