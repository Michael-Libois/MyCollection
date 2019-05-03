using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.DataContracts;
using Common.BTO;
using DAL.Entities;
using DAL.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCollection.Data;
using Newtonsoft.Json;
using BLL.UserCases;


namespace MyCollection.Controllers
{

    
    public class IMDBController : Controller
    {
        //public async Task<List<IMDBMovieSummary>> GetMovies(string name)
        //{
        //    var client = new HttpClient();
        //    var response = await client.GetAsync("http://www.omdbapi.com/?apikey=3fb1023d&s=" + name);
        //    var content = await response.Content.ReadAsStringAsync();
        //    var movies = JsonConvert.DeserializeObject<JsonRetourIMDB>(content).Search.ToList();

        //    return movies;


        //}
        
        private IRepositoryGeneric<MovieEF> repository = null;

        public IMDBController()
        {
            
            this.repository = new RepositoryGeneric<MovieEF>();
        }
        


        public ActionResult GetMoviesByName(string name)
        {
            var guest = new Visitor();

            var model = guest.SearchMoviesByName(name);

            return View(model);

        }

        public ActionResult GetMovieDetail(string imdbid)
        {
            var guest = new Visitor();

            var model = guest.SearchDetailsOfMovie(imdbid);

            return View(model);
        }

        public ActionResult AddToCollection(MovieDetailBTO imdbmovie)
        {
            
            try
            {
                var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                var userUC = new User(currentUser, repository);

                userUC.AddToUserCollection(imdbmovie);

                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index","Home");
            }
            catch(Exception Ex)
            {
                return View();
            }

        }
    }
}