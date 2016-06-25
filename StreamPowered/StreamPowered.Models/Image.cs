﻿using System.ComponentModel.DataAnnotations;

namespace StreamPowered.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
