using System.ComponentModel.DataAnnotations;

namespace Snippy.Web.Models.ViewModels
{
    public class LabelPreviewViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int SnippetsCount { get; set; }
    }
}