using System.Collections.Generic;

namespace Snippy.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<SnippetPreviewViewModel> Snippets { get; set; }

        public IEnumerable<LabelPreviewViewModel> Labels { get; set; }

        public IEnumerable<CommentPreviewViewModel> Comments { get; set; }

    }
}