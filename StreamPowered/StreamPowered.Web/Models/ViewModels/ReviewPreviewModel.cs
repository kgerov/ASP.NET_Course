using System;

namespace StreamPowered.Web.Models.ViewModels
{
    public class ReviewPreviewModel
    {
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public string User { get; set; }

        public int GameId { get; set; }

        public string Game { get; set; }
    }
}