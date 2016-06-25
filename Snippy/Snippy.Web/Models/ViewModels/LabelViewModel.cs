using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Web.Models.ViewModels
{
    public class LabelViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}