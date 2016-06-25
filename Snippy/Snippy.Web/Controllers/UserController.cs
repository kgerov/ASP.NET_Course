using Snippy.Data.UnitOfWork;

namespace Snippy.Web.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ISnippyData data)
            : base(data)
        {
        }
    }
}