using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Web.Models.ViewModels
{
    public class SnippetViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Code { get; set; }

        public LanguageViewModel Language { get; set; }

        public string User { get; set; }

        public DateTime CreationTime { get; set; }

        public IEnumerable<LabelViewModel> Labels { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}