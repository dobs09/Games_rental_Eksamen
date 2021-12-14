using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Games_Rental_MVC.Models
{
    public partial class Members
    {
        public Members()
        {
            RentalHistories = new HashSet<RentalHistories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<RentalHistories> RentalHistories { get; set; }
    }
}
