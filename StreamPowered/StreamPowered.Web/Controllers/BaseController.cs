﻿using System;
using System.Linq;
using System.Web.Routing;
using StreamPowered.Models;
using StreamPowered.Data.UnitOfWork;

namespace StreamPowered.Web.Controllers
{
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        private IStreamPoweredData data;
        private User userProfile;

        protected BaseController(IStreamPoweredData data)
        {
            this.Data = data;
        }

        protected BaseController(IStreamPoweredData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        public IStreamPoweredData Data { get; private set; }

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