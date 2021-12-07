using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Games_rental_API.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Payment { get; set; }
        public string Name { get; set; }
        public string RentalDates { get; set; }
                
        public bool isAvailable { get; set; }

        [JsonIgnore]
        public virtual List<RentalHistory> History { get; set; }
    }
}
