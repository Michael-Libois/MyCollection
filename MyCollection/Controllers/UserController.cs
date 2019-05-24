using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases;
using Common.MTO;
using Common.DataContracts;
using DAL.Entities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MyCollection.ViewModels;
using DAL.UnitOfWork;

namespace MyCollection.Controllers
{
    public class UserController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMoviesByPostalCode()
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
            var userUC = new User(currentUser, unitOfWork);
            var users = userUC.ShowUsersSamePostalMovies();

            var vm = new PostalMessageViewModel
            {
                ListMoviePostal = users.ToList(),
                Message = new Message()
            };




            return View(vm);
        }




        public IActionResult FilterMoviesByPostalCode(string FilterType, string SearchString)
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
            var userUC = new User(currentUser, unitOfWork);
            var users = userUC.ShowUsersSamePostalMovies();

            var listfilter = userUC.FilterMovies(users, FilterType, SearchString);



            var vm = new PostalMessageViewModel
            {
                ListMoviePostal = listfilter.ToList(),
                Message = new Message()
            };




            return View("GetMoviesByPostalCode", vm);
        }
    }
}