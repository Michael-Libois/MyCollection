using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases;
using Common.MTO;
using Common.DataContracts;
using DAL.Entities;
using DAL.Repo;
using DAL.Converters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using DAL.UnitOfWork;

namespace MyCollection.Controllers
{
    [Authorize]
    public class MovieController : MicBaseController
    {
        public MovieController(IUnitOfWork unitOfWork) :base(unitOfWork)
        {

        }

        //public MovieController(IRepositoryGeneric<Movie> repository)
        //{
        //    this.repository = repository;
        //}


        // GET: Movie
        //public ActionResult Index()
        //{
        //    var model = repository.Filter();
        //    return View(model);
        //}

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            var moviedetail = userUC.DisplayMovieDetail(id);
            return View(moviedetail);
        }


        public ActionResult DetailsPostal(int id)
        {
            var moviedetail = userUC.DisplayMovieDetail(id);
            return View(moviedetail);
        }



        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieDetail movie)
        {
            try
            {
                userUC.CreateMovie(movie);

                return RedirectToAction("DisplayAllMyMovies", "Movie");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            MovieDetail model = userUC.DisplayMovieDetail(id);

            //TODO EF to Common.MTO.MovieDetail
            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieDetail movie)
        {
            if (ModelState.IsValid)
            {
                
                userUC.EditMovie(movie);
                
                return RedirectToAction("DisplayAllMyMovies", "Movie");
            }
            else
            {
                return View(movie);
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int Id)
        {
            userUC.DeleteFromUserCollection(Id);


            return RedirectToAction("DisplayAllMyMovies", "Movie");
        }

        // POST: Movie/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult PlayMovie()
        {
            return View();
        }

        public ActionResult DisplayAllMyMovies()
        {

            var displayUrl = UriHelper.GetDisplayUrl(Request);


            ViewData["URL"] = GetBuildedUrl(displayUrl);


            var movies = userUC.DisplayMyMovies();

            return View(movies);
        }

        public ActionResult DisplayAllMoviesByUser(string UserID)
        {

            var displayUrl = UriHelper.GetDisplayUrl(Request);

            ViewData["URL"] = ViewData["URL"] = GetBuildedUrl(displayUrl); ;


            var movies = userUC.DisplayMoviesByUserId(UserID);

            return View("DisplayAllMyMovies", movies);
        }

        public ActionResult DisplayMyMoviesByFilter(string FilterType, string SearchString)
        {
            var displayUrl = UriHelper.GetDisplayUrl(Request);
            ViewData["URL"] = GetBuildedUrl(displayUrl);
            if (SearchString != null)
            {
                

                var movies = userUC.FilterMyMovies(FilterType, SearchString);

                ViewData["FilterType"] = FilterType;
                ViewData["SearchString"] = SearchString;

                return View("DisplayAllMyMovies", movies);
            }
            var nomovies = new List<MovieSummary>();
            return View("DisplayAllMyMovies", nomovies);
            
        }

     


    }
}