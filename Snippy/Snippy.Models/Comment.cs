using System;
using System.ComponentModel.DataAnnotations;

namespace Snippy.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int SnippetId { get; set; }

        public virtual Snippet Snippet { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
