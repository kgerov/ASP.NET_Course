using System;
using System.Linq;
using System.Web.Mvc;
using StreamPowered.Data.UnitOfWork;
using StreamPowered.Models;
using StreamPowered.Web.Models.BindingModels;

namespace StreamPowered.Web.Controllers
{
    public class RatingsController : BaseController
    {
        public RatingsController(IStreamPoweredData data)
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Rate(RatingBindingModel rating)
        {
            var game = this.Data.Games.Find(rating.GameId);

            if (game == null)
            {
                return this.HttpNotFound("Game does not exist");
            }

            var newRating = new Rating()
            {
                AuthorId = this.UserProfile.Id,
                GameId = rating.GameId,
                Value = rating.Value
            };

            this.Data.Ratings.Add(newRating);
            this.Data.SaveChanges();

            game = this.Data.Games.Find(rating.GameId);
            double result = (game.Ratings.Sum(x => x.Value)*1.0)/game.Ratings.Count;

            return this.Content(String.Format("{0:0.00}", result));
        }
    }
}