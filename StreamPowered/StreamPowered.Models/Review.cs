using System;
using System.ComponentModel.DataAnnotations;

namespace StreamPowered.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}