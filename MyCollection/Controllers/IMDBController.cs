﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.DataContracts;
using Common.MTO;
using DAL.Entities;
using DAL.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCollection.Data;
using Newtonsoft.Json;
using BLL.UserCases;
using Microsoft.AspNetCore.Authorization;
using DAL.UnitOfWork;

namespace MyCollection.Controllers
{


    public class IMDBController : MicBaseController
    {
        //public async Task<List<IMDBMovieSummary>> GetMovies(string name)
        //{
        //    var client = new HttpClient();
        //    var response = await client.GetAsync("http://www.omdbapi.com/?apikey=3fb1023d&s=" + name);
        //    var content = await response.Content.ReadAsStringAsync();
        //    var movies = JsonConvert.DeserializeObject<JsonRetourIMDB>(content).Search.ToList();

        //    return movies;


        //}

        public IMDBController(IUnitOfWork UnitOfWork) :base(UnitOfWork)
        {
        }



        public ActionResult GetMoviesByName(string name)
        {

            var model = visitorUC.SearchMoviesByName(name);

            if (model.First()?.imdbID != null)
            {
                return View(model);
            }

            return RedirectToAction("Index", "Home");



            //return RedirectToAction("Index", "Home");

            //if (model.Count() == 0) return RedirectToAction("Index", "Home");
            //    else
            //    return View(model);


        }

        public ActionResult GetMovieDetail(string imdbid)
        {
            var model = visitorUC.SearchDetailsOfMovie(imdbid);

            return View(model);
        }
        [Authorize]
        public ActionResult AddToCollection(MovieDetail imdbmovie)
        {

            //try
            //{
           

           userUC.AddToUserCollection(imdbmovie);

            //return RedirectToAction(nameof(Index));
            return RedirectToAction("DisplayAllMyMovies", "Movie");
            //}
            //catch(Exception Ex)
            //{
            //    return View();
            //}

        }
    }
}