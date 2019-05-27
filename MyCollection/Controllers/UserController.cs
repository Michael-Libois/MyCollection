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
using Microsoft.AspNetCore.Identity;

namespace MyCollection.Controllers
{
    public class UserController : Controller
    {

        private readonly IUnitOfWork unitOfWork;

        private readonly UserManager<ApplicationUserEF> _userManager;
        private readonly SignInManager<ApplicationUserEF> _signInManager;

        public UserController(IUnitOfWork unitOfWork, UserManager<ApplicationUserEF> userManager,
            SignInManager<ApplicationUserEF> signInManager)
        {
            this.unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
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

            var cur = _userManager.Users.FirstOrDefault(u => u.Id == currentUser);
            ViewBag.ac = cur.AcceptShared;

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