using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Web.Models.ViewModels
{
    public class SnippetPreviewViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public IEnumerable<LabelPreviewViewModel> Labels { get; set; }
    }
}