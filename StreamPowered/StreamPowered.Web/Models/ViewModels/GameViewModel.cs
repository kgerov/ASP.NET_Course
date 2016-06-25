using System.Collections.Generic;

namespace StreamPowered.Web.Models.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Rating { get; set; }

        public GenreViewModel Genre { get; set; }

        public string Description { get; set; }

        public string SystemRequirements { get; set; }

        public IEnumerable<ReviewModel> Reviews { get; set; }

        public IEnumerable<string> Images { get; set; }

        public IEnumerable<UserRatingsViewModel> UsersRatings { get; set; }
    }
}