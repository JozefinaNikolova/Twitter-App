namespace Twitter.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Twitter.Web.Models;
    public class UserController : BaseController
    {
        public ActionResult Index(string username)
        {
            var user = this.Data.Users
                .All()
                .Where(u => u.UserName == username)
                .Select(UserViewModel.Create)
                .FirstOrDefault();

            return this.View(user);
        }
    }
}