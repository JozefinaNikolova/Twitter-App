namespace Twitter.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Twitter.Data;
    using Twitter.Models;
    public abstract class BaseController : Controller
    {
        private ITwitterData data;

        protected BaseController(ITwitterData data)
        {
            this.data = data;
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
    }
}