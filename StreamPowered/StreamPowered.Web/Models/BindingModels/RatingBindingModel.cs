using System.ComponentModel.DataAnnotations;

namespace StreamPowered.Web.Models.BindingModels
{
    public class RatingBindingModel
    {
        public int GameId { get; set; }

        [Required]
        public int Value { get; set; }

        public string AuthorUserName { get; set; }
    }
}