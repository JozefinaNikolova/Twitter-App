namespace Twitter.Models
{
    using System.Collections.Generic;
    public class Tweet
    {
        private ICollection<User> favouriteBy;
        private ICollection<Tweet> replies;

        public Tweet()
        {
            this.favouriteBy = new HashSet<User>();
            this.replies = new HashSet<Tweet>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string Url { get; set; }

        public virtual Tweet ReplyTo { get; set; }

        public virtual User PostedBy { get; set; }

        public virtual ICollection<User> FavouriteBy
        {
            get { return this.favouriteBy; }
            set { this.favouriteBy = value; }
        }

        public virtual ICollection<Tweet> Replies
        {
            get { return this.replies; }
            set { this.replies = value; }
        }
    }
}
