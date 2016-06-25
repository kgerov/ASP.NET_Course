using System.Collections.Generic;

namespace Snippy.Web.Models.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}