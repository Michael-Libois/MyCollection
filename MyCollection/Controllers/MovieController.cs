using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases;
using Common.BTO;
using Common.DataContracts;
using DAL.Entities;
using DAL.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MyCollection.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private IRepositoryGeneric<MovieEF, int> repository = null;

        public MovieController(IRepositoryGeneric<MovieEF, int> Repository)
        {
            this.repository = Repository;
        }

        //public MovieController(IRepositoryGeneric<Movie> repository)
        //{
        //    this.repository = repository;
        //}


        // GET: Movie
        public ActionResult Index()
        {
            var model = repository.Filter();
            return View(model);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userUC = new User(currentUser, repository, null, null);
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
        public ActionResult Create(MovieEF movie)
        {
            try
            {
                // TODO: Add insert logic here
                repository.Create(movie);
                repository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            MovieEF model = repository.GetById(id);
            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieEF movie)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(movie);
                repository.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(movie);
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int Id)
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userUC = new User(currentUser, repository, null,null);
            userUC.DeleteFromUserCollection(Id);


            return RedirectToAction("DisplayAllMoviesByUser", "Movie");
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PlayMovie()
        {
            return View();
        }

        public ActionResult DisplayAllMyMovies()
        {

            var displayUrl = UriHelper.GetDisplayUrl(Request);
            var urlBuilder =
            new UriBuilder(displayUrl)
            {
                Query = null,
                Fragment = null
            };
            string url = urlBuilder.ToString();


            ViewData["URL"] = url;



            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var userUC = new User(currentUser, repository, null, null);

            var movies = userUC.DisplayMyMovies();

            return View(movies);
        }

        public ActionResult DisplayAllMoviesByUser(string UserID)
        {

            var displayUrl = UriHelper.GetDisplayUrl(Request);
            var urlBuilder =
            new UriBuilder(displayUrl)
            {
                Query = null,
                Fragment = null
            };
            string url = urlBuilder.ToString();


            ViewData["URL"] = url;



            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var userUC = new User(currentUser, repository, null, null);

            var movies = userUC.DisplayMoviesByUserId(UserID);

            return View("DisplayAllMyMovies", movies);
        }

        public ActionResult DisplayMyMoviesByFilter(string FilterType, string SearchString)
        {

            var displayUrl = UriHelper.GetDisplayUrl(Request);
            var urlBuilder =
            new UriBuilder(displayUrl)
            {
                Query = null,
                Fragment = null
            };
            string url = urlBuilder.ToString();


            ViewData["URL"] = url;




            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var userUC = new User(currentUser, repository, null, null);

            var movies = userUC.FilterMyMovies(FilterType, SearchString);

            ViewData["FilterType"] = FilterType;
            ViewData["SearchString"] = SearchString;

            return View("DisplayAllMyMovies",movies);
        }

     


    }
}