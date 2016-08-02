namespace Twitter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Models;

    public class TwitterContext : IdentityDbContext<User>
    {
        public TwitterContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TwitterContext Create()
        {
            return new TwitterContext();
        }
    }
}
