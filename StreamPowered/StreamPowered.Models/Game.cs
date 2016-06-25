using System.Collections.Generic;

namespace StreamPowered.Models
{
    public  class Game
    {
        private ICollection<Image> images;
        private ICollection<Rating> ratings;
        private ICollection<Review> reviews; 

        public Game()
        {
            this.images = new HashSet<Image>();
            this.ratings = new HashSet<Rating>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public string SystemRequirements { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Image> Images 
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}