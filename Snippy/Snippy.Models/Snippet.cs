﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Snippy.Models
{
    public class Snippet
    {
        private ICollection<Label> labels;
        private ICollection<Comment> comments;

        public Snippet()
        {
            this.labels = new HashSet<Label>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Code { get; set; }

        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual ICollection<Label> Labels
        {
            get { return this.labels; }
            set { this.labels = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}