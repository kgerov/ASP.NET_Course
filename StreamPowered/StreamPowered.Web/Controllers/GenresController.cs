using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using StreamPowered.Data.UnitOfWork;
using StreamPowered.Web.Models.ViewModels;

namespace StreamPowered.Web.Controllers
{
    public class GenresController : BaseController
    {
        public GenresController(IStreamPoweredData data)
            : base(data)
        {
        }

        public ActionResult Details(int id)
        {
            var genre = this.Data.Genres.Find(id);

            if (genre == null)
            {
                return this.HttpNotFound("Genre deos not exist");
            }

            var genreModel = Mapper.Map<GenreDetailsViewModel>(genre);

            return View(genreModel);
        }

        public ActionResult GetDropDownGenres()
        {
            var genres = this.Data.Genres.All();

            var model = Mapper.Map<IEnumerable<GenreViewModel>>(genres);

            return this.PartialView("DropdownGenre", model);
        }
    }
}