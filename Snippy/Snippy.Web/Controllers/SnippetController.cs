using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Snippy.Data.UnitOfWork;
using Snippy.Web.Models.ViewModels;

namespace Snippy.Web.Controllers
{
    public class SnippetController : BaseController
    {
        private const int pageSize = 5;
 
        public SnippetController(ISnippyData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var snippets = this.Data.Snippets.All()
                .OrderByDescending(x => x.CreationTime)
                .Skip((page - 1)*pageSize)
                .Take(pageSize);

            this.ViewBag.MaxPages = (this.Data.Snippets.All().Count() + pageSize - 1) / pageSize;
            this.ViewBag.CurrentPage = page;

            var snippetPreviews = Mapper.Map<IEnumerable<SnippetPreviewViewModel>>(snippets);

            return View(snippetPreviews);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var snippet = this.Data.Snippets.Find(id);

            var snippetModel = Mapper.Map<SnippetViewModel>(snippet);

            return this.View(snippetModel);
        }
    }
}