using DAL.Context;
using DAL.Entities;
using DAL.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    //public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    //{

    //    public MovieRepository(DatabaseContext databaseContext)
    //    : base(databaseContext)
    //    { }

    //    public async Task CreateMovieAsync(Movie movie)
    //    {
    //        //movie.Id = Guid.NewGuid();
    //        Create(movie);
    //        await SaveAsync();
    //    }

    //    public async Task DeleteMovieAsync(Movie movie)
    //    {
    //        Delete(movie);
    //        await SaveAsync();
    //    }

    //    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    //    {
    //        return await GetAll()
    //        .OrderBy(x => x.Title)
    //        .ToListAsync();
    //    }

    //    public async Task<Movie> GetMovieByIdAsync(Guid movieId)
    //    {
    //        return await GetByCondition(o => o.Id.Equals(movieId))
    //         .DefaultIfEmpty(new Movie())
    //         .SingleAsync();
    //    }

    //    public async Task UpdateMovieAsync(Movie dbMovie, Movie movie)
    //    {
    //        dbMovie.Map(movie);
    //        Update(dbMovie);
    //        await SaveAsync();
    //    }
    //}
}
