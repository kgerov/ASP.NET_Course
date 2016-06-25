using System.ComponentModel.DataAnnotations;

namespace StreamPowered.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(1, 5)]
        [Required]
        public int Value { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
