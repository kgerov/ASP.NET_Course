using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using StreamPowered.Web.Models.ViewModels;

namespace StreamPowered.Web.Models.BindingModels
{
    public class GameBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DisplayName("System Requirements")]
        public string SystemRequirements { get; set; }

        public IEnumerable<string> Images { get; set; }

        [Required]
        [DisplayName("Genre")]
        public int GenreId { get; set; }
    }
}