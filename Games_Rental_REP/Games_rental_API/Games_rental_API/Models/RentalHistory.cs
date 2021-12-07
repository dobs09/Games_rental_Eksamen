using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Games_rental_API.Models
{
    public class RentalHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime RentalDate { get; set; }
        
        public int GameID { get; set; }
        
        public int MemberID { get; set; }

        [JsonIgnore]
        public virtual Member Members { get; set; }
        public virtual Game Games { get; set; }
    }
}
