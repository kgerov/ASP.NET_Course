using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using StreamPowered.Data.UnitOfWork;
using StreamPowered.Web.Extensions;
using StreamPowered.Web.Models.ViewModels;

namespace StreamPowered.Web.Controllers
{
    public class HomeController : BaseController
    {
        private const int itemsPerPage = 5;

        public HomeController(IStreamPoweredData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var games = this.Data.Games.All()
                .OrderByDescending(g => (g.Ratings.Sum(r => r.Value) * 1.0 )/g.Ratings.Count)
                .ThenBy(g => g.Title)
                .Take(itemsPerPage);

            var reviews = this.Data.Reviews.All()
                .OrderByDescending(r => r.CreationTime)
                .Take(itemsPerPage);

            HomeViewModel model = new HomeViewModel()
            {
                Games = Mapper.Map<IEnumerable<GamePreviewModel>>(games),
                Reviews = Mapper.Map<IEnumerable<ReviewPreviewModel>>(reviews)
            };

            return View(model);
        }
    }
}

//this.AddNotification("Welcome to my website!", NotificationType.SUCCESS);