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
    public class UserController : MicBaseController
    {

        //private readonly IUnitOfWork unitOfWork;

        private readonly UserManager<ApplicationUserEF> _userManager;
        private readonly SignInManager<ApplicationUserEF> _signInManager;

        public UserController(IUnitOfWork unitOfWork, UserManager<ApplicationUserEF> userManager,
            SignInManager<ApplicationUserEF> signInManager) : base(unitOfWork)
        {
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

            ViewData["URL"] = GetBuildedUrl(displayUrl); ;

            var cur = _userManager.Users.FirstOrDefault(u => u.Id == userID);
            ViewBag.ac = cur.AcceptShared;

            var users = userUC.ShowUsersSamePostalMovies();

            var vm = new PostalMessageViewModel
            {
                ListMoviePostal = users.ToList(),
                Message = new Message()
            };




            return View(vm);
        }

        //private string GetCurrentUserID()
        //    => User.FindFirst(ClaimTypes.NameIdentifier).Value;

        //private string GetBuildedUrl(string displayUrl)
        //    => (new UriBuilder(displayUrl)
        //    {
        //        Query = null,
        //        Fragment = null
        //    }).ToString();


        public IActionResult FilterMoviesByPostalCode(string FilterType, string SearchString)
        {

            var displayUrl = UriHelper.GetDisplayUrl(Request);
            ViewData["URL"] = GetBuildedUrl(displayUrl);
            if (SearchString != null)
            {

                var users = userUC.ShowUsersSamePostalMovies();

                var listfilter = userUC.FilterMovies(users, FilterType, SearchString);

                var cur = _userManager.Users.FirstOrDefault(u => u.Id == userID);
                ViewBag.ac = cur.AcceptShared;


                var vm = new PostalMessageViewModel
                {
                    ListMoviePostal = listfilter.ToList(),
                    Message = new Message()
                };

                return View("GetMoviesByPostalCode", vm);
            }

            var cur2 = _userManager.Users.FirstOrDefault(u => u.Id == userID);
            ViewBag.ac = cur2.AcceptShared;
            var nofilm = new PostalMessageViewModel
            {
                ListMoviePostal = new List<MovieSummary>(),
                Message = new Message()
            };
            return View("GetMoviesByPostalCode", nofilm);
        }
    }
}