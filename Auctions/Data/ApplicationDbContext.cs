using Auctions.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Auctions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

            public DbSet<Bid> Bids { get; set; }
            public DbSet<Listing> Listings { get; set; }
            public DbSet<Comment> Comments { get; set; }
    }
}
