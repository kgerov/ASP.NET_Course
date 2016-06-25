using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using StreamPowered.Data.UnitOfWork;
using StreamPowered.Models;
using StreamPowered.Web.Extensions;
using StreamPowered.Web.Models.BindingModels;
using StreamPowered.Web.Models.ViewModels;

namespace StreamPowered.Web.Controllers
{
    public class GamesController : BaseController
    {
        private const int pageSize = 5;

        public GamesController(IStreamPoweredData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var games = this.Data.Games.All()
                .OrderBy(x => x.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            this.ViewBag.MaxPages = (this.Data.Games.All().Count() + pageSize - 1) / pageSize;
            this.ViewBag.CurrentPage = page;

            var gamePreviews = Mapper.Map<IEnumerable<GamePreviewModel>>(games);

            return this.View(gamePreviews);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var game = this.Data.Games.Find(id);

            if (game == null)
            {
                return this.HttpNotFound();
            }

            var model = Mapper.Map<GameViewModel>(game);

            return this.View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var genres = this.Data.Genres.All();
            this.ViewBag.Genres = genres.Select(g => new SelectListItem()
            {
                Value = g.Id.ToString(),
                Text = g.Name
            });

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(GameBindingModel game)
        {
            ICollection<Image> newImages = new List<Image>();

            foreach (var image in game.Images)
            {
                Image newImage = new Image()
                {
                    Url = image
                };

                newImages.Add(newImage);
                this.Data.Images.Add(newImage);
            }

            this.Data.SaveChanges();

            Game newGame = new Game()
            {
                AuthorId = this.UserProfile.Id,
                Description = game.Description,
                Title = game.Title,
                GenreId = game.GenreId,
                SystemRequirements = game.SystemRequirements,
                Images = newImages
            };

            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();

            this.AddNotification("Successfully added game!", NotificationType.SUCCESS);

            return this.RedirectToAction("Index", "Games");
        }
    }
}