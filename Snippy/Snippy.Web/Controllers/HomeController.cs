using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Snippy.Data.UnitOfWork;
using Snippy.Web.Models.ViewModels;

namespace Snippy.Web.Controllers
{
    public class HomeController : BaseController
    {
        private const int numberOfItmes = 5;

        public HomeController(ISnippyData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var latestSnippets = this.Data.Snippets.All()
                .OrderByDescending(s => s.CreationTime)
                .Take(numberOfItmes);
            var bestLabels = this.Data.Labels.All()
                .OrderByDescending(l => l.Snippets.Count())
                .Take(numberOfItmes);
            var latestComments = this.Data.Comments.All()
                .OrderByDescending(c => c.CreationTime)
                .Take(numberOfItmes);

            var model = new HomeViewModel()
            {
                Labels = Mapper.Map<IEnumerable<LabelPreviewViewModel>>(bestLabels),
                Snippets = Mapper.Map<IEnumerable<SnippetPreviewViewModel>>(latestSnippets),
                Comments = Mapper.Map<IEnumerable<CommentPreviewViewModel>>(latestComments)
            };

            return this.View(model);
        }
    }
}