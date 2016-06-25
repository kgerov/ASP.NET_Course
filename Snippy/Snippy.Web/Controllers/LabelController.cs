using System.Web.Mvc;
using Snippy.Data.UnitOfWork;

namespace Snippy.Web.Controllers
{
    public class LabelController : BaseController
    {
        public LabelController(ISnippyData data)
            : base(data)
        {
        }

        // GET: Label
        public ActionResult Index()
        {
            return View();
        }
    }
}