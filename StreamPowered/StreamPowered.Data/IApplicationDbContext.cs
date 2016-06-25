using System.Data.Entity;
using StreamPowered.Models;

namespace StreamPowered.Data
{
    public interface IApplicationDbContext
    {
        IDbSet<Game> Games { get; set; }

        IDbSet<Genre> Genres { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<Image> Images { get; set; }

        int SaveChanges();
    }
}
