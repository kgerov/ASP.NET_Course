using System.Web.Mvc;
using StreamPowered.Data.UnitOfWork;

namespace StreamPowered.Web.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IStreamPoweredData data)
            : base(data)
        {
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
    }
}