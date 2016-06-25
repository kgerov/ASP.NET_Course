namespace Snippy.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Routing;
    using Snippy.Data.UnitOfWork;
    using Snippy.Models;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        private ISnippyData data;
        private User userProfile;

        protected BaseController(ISnippyData data)
        {
            this.Data = data;
        }

        protected BaseController(ISnippyData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        public ISnippyData Data { get; private set; }

        public User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext request, AsyncCallback callback, object state)
        {
            if (request.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = request.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(request, callback, state);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}