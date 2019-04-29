using DAL.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCollection.Logic
{
    public class IMDBLogic
    {

        public async Task<IEnumerable<IMDBMovieResult>> GetMovies(string name)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.omdbapi.com/?apikey=3fb1023d&s=" + name);
            var content = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<JsonRetourIMDB>(content).Search.AsEnumerable();

            return movies;


        }


        public async Task<IMDBMovieResult> GetMovieDetail(string imdbID)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://www.omdbapi.com/?apikey=3fb1023d&i=" + imdbID);
            var content = await response.Content.ReadAsStringAsync();
            var movie = JsonConvert.DeserializeObject<IMDBMovieResult>(content);

            return movie;


        }

    }
}
