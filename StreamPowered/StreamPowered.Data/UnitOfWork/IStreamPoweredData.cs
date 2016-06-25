using StreamPowered.Data.Repositories;
using StreamPowered.Models;

namespace StreamPowered.Data.UnitOfWork
{
    public interface IStreamPoweredData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Genre> Genres { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Review> Reviews { get; }

        IRepository<Image> Images { get; }

        int SaveChanges();
    }
}
