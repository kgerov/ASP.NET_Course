using System;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Web.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string User { get; set; }

        public int SnippetId { get; set; }

        public string SnippetTitle { get; set; }

        public DateTime CreationTime { get; set; }
    }
}