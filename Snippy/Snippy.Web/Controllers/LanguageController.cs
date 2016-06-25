using System.Web.Mvc;
using Snippy.Data.UnitOfWork;

namespace Snippy.Web.Controllers
{
    public class LanguageController : BaseController
    {
        public LanguageController(ISnippyData data)
            : base(data)
        {
        }

        // GET: Language
        public ActionResult Index()
        {
            return View();
        }
    }
}