using Common.DTO.IMDBProxy;
using DAL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL.ExternalData
{
    public class IMDBProxy
    {

        public async Task<IEnumerable<IMDBMovieSummary>> GetMovies(string name)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.omdbapi.com/?apikey=3fb1023d&s=" + name /*+"&page=100"*/);
            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<JsonRetourIMDB>(content).Search.AsEnumerable();

            return movies != null ? movies : new List<IMDBMovieSummary>();
        }
        public async Task<IEnumerable<IMDBMovieSummary>> GetMoviesT(string name)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.omdbapi.com/?apikey=3fb1023d&t=" + name);
            var content = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<IMDBMovieSummary>(content);

            return movie != null ? new List<IMDBMovieSummary> { movie } : new List<IMDBMovieSummary>();

        }

        public async Task<IMDBMovieDetail> GetMovieDetail(string imdbID)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.omdbapi.com/?apikey=3fb1023d&i=" + imdbID);
            var content = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<IMDBMovieDetail>(content);

            return movie != null ? movie : new IMDBMovieDetail();
        }
    }
}
