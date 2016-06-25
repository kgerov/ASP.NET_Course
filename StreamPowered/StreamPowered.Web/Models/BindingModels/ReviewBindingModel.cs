using System.ComponentModel.DataAnnotations;

namespace StreamPowered.Web.Models.BindingModels
{
    public class ReviewBindingModel
    {
        public int GamePublicationId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}