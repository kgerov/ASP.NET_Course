using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using StreamPowered.Data.UnitOfWork;
using StreamPowered.Models;
using StreamPowered.Web.Extensions;
using StreamPowered.Web.Models.BindingModels;
using StreamPowered.Web.Models.ViewModels;

namespace StreamPowered.Web.Controllers
{
    public class ReviewsController : BaseController
    {
        public ReviewsController(IStreamPoweredData data)
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ReviewBindingModel review)
        {
            var game = this.Data.Games.Find(review.GamePublicationId);

            if (game == null)
            {
                return this.HttpNotFound("Game does not exist");
            }

            var newReview = new Review()
            {
                Content = review.Content,
                AuthorId = this.UserProfile.Id,
                CreationTime = DateTime.Now,
                GameId = game.Id
            };

            this.Data.Reviews.Add(newReview);
            this.Data.SaveChanges();

            var modelReview = Mapper.Map<ReviewModel>(newReview);

            return this.PartialView("DisplayTemplates/ReviewModel", modelReview);
        }
    }
}