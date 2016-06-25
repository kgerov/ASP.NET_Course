using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StreamPowered.Models
{
    public class Genre
    {
        private ICollection<Game> games;

        public Genre()
        {
            this.games = new HashSet<Game>();    
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Game> Games 
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}
