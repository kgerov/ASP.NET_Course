using System.Collections.Generic;

namespace StreamPowered.Web.Models.ViewModels
{
    public class GenreDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<GamePreviewModel> Games { get; set; }
    }
}