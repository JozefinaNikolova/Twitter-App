namespace Twitter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using Twitter.Data.Migrations;
    using Twitter.Models;

    public class TwitterContext : IdentityDbContext<User>
    {
        public TwitterContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterContext, Configuration>());
        }

        public IDbSet<Tweet> Tweets { get; set; }
        public IDbSet<Message> Messages { get; set; }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.Followers)
                .WithMany(x => x.FollowingUsers)
                .Map(m =>
                {
                    m.MapLeftKey("User");
                    m.MapRightKey("FollowingUser");
                    m.ToTable("UsersFollowers");
                });

            modelBuilder.Entity<Tweet>()
                .HasRequired(x => x.PostedBy)
                .WithMany(x => x.Tweets)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasMany(x => x.FavouriteBy)
                .WithMany(x => x.Favourites);

            modelBuilder.Entity<Tweet>()
                .HasMany(x => x.Replies)
                .WithOptional(x => x.ReplyTo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(x => x.Sender)
                .WithMany(x => x.SentMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(x => x.Respondent)
                .WithMany(x => x.ReceivedMessages)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
