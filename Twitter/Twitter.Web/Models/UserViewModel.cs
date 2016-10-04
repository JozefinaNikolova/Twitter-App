namespace Twitter.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using Twitter.Models;

    public class UserViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public IEnumerable<TweetViewModel> Tweets { get; set; }

        public static Expression<Func<User, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel()
                {
                    Username = u.UserName,
                    Email = u.Email,
                    FullName = u.FullName,
                    AvatarUrl = u.AvatarUrl,
                    Summary = u.Summary,
                    Tweets =  u.Tweets
                        .Select(t => new TweetViewModel()
                        {
                            PostedBy = t.PostedBy.UserName,
                            Content = t.Content,
                            Url = t.Url
                        })
                };
            }
        }
    }
}