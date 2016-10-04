namespace Twitter.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Twitter.Data;
    using Twitter.Web.Models;
    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            var tweets = this.Data.Tweets
                .All()
                .OrderByDescending(t => t.CreatedOn)
                .Select(TweetViewModel.Create);

            return this.View(tweets);
        }
       
        public ActionResult Profile()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}