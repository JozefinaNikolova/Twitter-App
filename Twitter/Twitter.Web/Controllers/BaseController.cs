namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Twitter.Data;
    using Twitter.Models;

    public abstract class BaseController : Controller
    {
        private ITwitterData data;
        private User userProfile;

        protected BaseController(ITwitterData data)
        {
            this.data = data;
        }

        protected BaseController(ITwitterData data, User userProfile)
            :this(data)
        {
            this.userProfile = userProfile;
        }

        protected BaseController()
            :this(new TwitterData(new TwitterContext()))
        {
        }

        public ITwitterData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public User UserProfile
        {
            get { return this.userProfile; }
            private set { this.userProfile = value; }
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if(requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == username);

                this.userProfile = user;
            }
            
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}