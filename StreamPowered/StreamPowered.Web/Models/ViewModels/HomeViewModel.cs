using System.Collections.Generic;

namespace StreamPowered.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<GamePreviewModel> Games { get; set; }

        public IEnumerable<ReviewPreviewModel> Reviews { get; set; }
    }
}