using System;
using System.Collections.Generic;
using StreamPowered.Data.Repositories;
using StreamPowered.Models;

namespace StreamPowered.Data.UnitOfWork
{
    public class StreamPoweredData : IStreamPoweredData
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDictionary<Type, object> repositories;

        public StreamPoweredData()
            : this(new ApplicationDbContext())
        {
        }

        public StreamPoweredData(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Game> Games
        {
            get { return this.GetRepository<Game>();; }
        }

        public IRepository<Genre> Genres
        {
            get { return this.GetRepository<Genre>(); }
        }

        public IRepository<Rating> Ratings
        {
            get { return this.GetRepository<Rating>(); }
        }

        public IRepository<Review> Reviews
        {
            get { return this.GetRepository<Review>(); }
        }

        public IRepository<Image> Images
        {
            get { return this.GetRepository<Image>(); }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof (T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                //if (type.IsAssignableFrom(typeof(Game)))
                //{
                //    typeOfRepository = typeof(Game);
                //}

                var repository = Activator.CreateInstance(typeOfRepository, this.dbContext);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
