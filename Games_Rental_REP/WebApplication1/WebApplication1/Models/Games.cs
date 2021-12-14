using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games_Rental_MVC.Models
{
    public partial class Games
    {
        public int Id { get; set; }
        public string Payment { get; set; }
        public string Name { get; set; }
        public string RentalDates { get; set; }
        public bool IsAvailable { get; set; }
        public int? RentalHistoryId { get; set; }

        public virtual RentalHistories RentalHistory { get; set; }
    }
}
