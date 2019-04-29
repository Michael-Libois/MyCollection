﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(Guid ownerId);
        //Task<MovieExtended> GetMovieWithDetailsAsync(Guid ownerId);
        Task CreateMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie dbMovie, Movie movie);
        Task DeleteMovieAsync(Movie movie);
    }
}