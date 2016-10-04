namespace Twitter.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Twitter.Models;
    using Twitter.Web.Models;

    public class TweetController : BaseController
    {
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(TweetViewModel model)
        {
            var tweet = new Tweet()
            {
                Url = model.Url,
                Content = model.Content,
                PostedBy = this.UserProfile
            };

            this.Data.Tweets.Add(tweet);
            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Favourite(int id)
        {
            var tweet = this.Data.Tweets.Find(id);
            if(!tweet.FavouriteBy.Contains(this.UserProfile))
            {
                tweet.FavouriteBy.Add(this.UserProfile);
                this.UserProfile.Favourites.Add(tweet);
            }
            else
            {
                tweet.FavouriteBy.Remove(this.UserProfile);
                this.UserProfile.Favourites.Remove(tweet);
            }
            
            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Retweet(int id)
        {
            var tweet = this.Data.Tweets.Find(id);

            if(tweet.PostedBy != this.UserProfile)
            {

                var newTweet = new Tweet()
                {
                    Url = tweet.Url,
                    Content = tweet.Content,
                    PostedBy = this.UserProfile
                };

                this.Data.Tweets.Add(newTweet);
                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}

