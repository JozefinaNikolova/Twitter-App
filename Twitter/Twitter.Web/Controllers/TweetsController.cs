namespace Twitter.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class TweetsController : BaseController
    {
        // GET: Tweets
        public ActionResult Index()
        {
            return View();
        }
    }
}