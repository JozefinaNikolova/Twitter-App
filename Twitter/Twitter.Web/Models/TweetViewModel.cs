namespace Twitter.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using Twitter.Models;
    public class TweetViewModel
    {
        public string Content { get; set; }

        public string Url { get; set; }

        public string PostedBy { get; set; }

        public static Expression<Func<Tweet, TweetViewModel>> Create
        {
            get
            {
                return t => new TweetViewModel()
                {
                    Content = t.Content,
                    Url = t.Url,
                    PostedBy = t.PostedBy.UserName
                };
            }
        }
    }
}