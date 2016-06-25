using System;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Web.Models.ViewModels
{
    public class CommentPreviewViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string Username { get; set; }

        public int SnippetId { get; set; }

        public string SnippetTitle { get; set; }

        public DateTime CreationTime { get; set; }
    }
}