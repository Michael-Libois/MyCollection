using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.interfaces;
using DAL.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCollection.Controllers
{
    public class MovieController : Controller
    {
        private IRepositoryGeneric<Movie> repository = null;

        public MovieController()
        {
            this.repository = new RepositoryGeneric<Movie>();
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
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
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
            Movie model = repository.GetById(id);
            return View(model);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
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
        public ActionResult Delete(int id)
        {
            return View();
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


    }
}