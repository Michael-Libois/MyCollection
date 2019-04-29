using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCollection.Logic;
using Newtonsoft.Json;


namespace MyCollection.Controllers
{

    
    public class IMDBController : Controller
    {
        //public async Task<List<IMDBMovieResult>> GetMovies(string name)
        //{
        //    var client = new HttpClient();
        //    var response = await client.GetAsync("http://www.omdbapi.com/?apikey=3fb1023d&s=" + name);
        //    var content = await response.Content.ReadAsStringAsync();
        //    var movies = JsonConvert.DeserializeObject<JsonRetourIMDB>(content).Search.ToList();

        //    return movies;

           
        //}
        


        public ActionResult GetMoviesByName(string name)
        {
            var a = new IMDBLogic();
            var model = Task.Run(() => a.GetMovies(name)).Result;

            return View(model);

        }

        public ActionResult GetMovieDetail(string imdbid)
        {
            var a = new IMDBLogic();
            var model = Task.Run(() => a.GetMovieDetail(imdbid)).Result;

            return View(model);

        }


    }
}