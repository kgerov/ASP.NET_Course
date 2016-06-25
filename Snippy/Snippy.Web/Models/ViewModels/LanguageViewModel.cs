using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Web.Models.ViewModels
{
    public class LanguageViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}