using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games_Rental_MVC.Models
{
    public partial class RentalHistories
    {
        public RentalHistories()
        {
            Games = new HashSet<Games>();
        }

        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public int GameId { get; set; }
        public int MemberId { get; set; }

        public virtual Members Member { get; set; }
        public virtual ICollection<Games> Games { get; set; }
    }
}
