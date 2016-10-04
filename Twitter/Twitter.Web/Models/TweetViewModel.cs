namespace Twitter.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;
    public class TweetViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public string PostedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int FavsCount { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> Create
        {
            get
            {
                return t => new TweetViewModel()
                {
                    Id = t.Id,
                    Content = t.Content,
                    Url = t.Url,
                    PostedBy = t.PostedBy.UserName,
                    CreatedOn = t.CreatedOn,
                    FavsCount = t.FavouriteBy.Count
                };
            }
        }
    }
}