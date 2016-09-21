namespace Twitter.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<User> followers;
        private ICollection<User> followingUsers;
        private ICollection<Tweet> tweets;
        private ICollection<Tweet> favourites;
        private ICollection<Message> sentMessages;
        private ICollection<Message> receivedMessages;

  
        public User()
        {
            this.followers = new HashSet<User>();
            this.followingUsers = new HashSet<User>();
            this.tweets = new HashSet<Tweet>();
            this.favourites = new HashSet<Tweet>();
            this.sentMessages = new HashSet<Message>();
            this.receivedMessages = new HashSet<Message>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public virtual ICollection<User> Followers
        {
            get { return this.followers; }
            set { this.followers = value; }
        }

        public virtual ICollection<User> FollowingUsers
        {
            get { return this.followingUsers; }
            set { this.followingUsers = value; }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }

        public virtual ICollection<Tweet> Favourites
        {
            get { return this.favourites; }
            set { this.favourites = value; }
        }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        public virtual ICollection<Message> ReceivedMessages
        {
            get { return this.receivedMessages; }
            set { this.receivedMessages = value; }
        }
    }
}
