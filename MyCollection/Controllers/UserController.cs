using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases;
using Common.BTO;
using Common.DataContracts;
using DAL.Entities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MyCollection.ViewModels;

namespace MyCollection.Controllers
{
    public class UserController : Controller
    {

        private IRepositoryGeneric<MovieEF, int> repository = null;
        private IRepositoryGeneric<AdressEF, int> adressRepository = null;
        private IRepositoryGeneric<ApplicationUserEF, string> userRepository =null;

        public UserController(IRepositoryGeneric<MovieEF, int> Repository,
            IRepositoryGeneric<AdressEF, int> AdRepository,
            IRepositoryGeneric<ApplicationUserEF, string> UserRepository)
        {
            this.repository = Repository;
            this.adressRepository = AdRepository;
            this.userRepository = UserRepository;
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
            var userUC = new User(currentUser, repository, adressRepository, userRepository);
            var users = userUC.ShowUsersSamePostalMovies();

            var vm = new PostalMessageViewModel
            {
                ListMoviePostal = users.ToList(),
                messagePost = new MessageBTO()
            };




            return View(vm);
        }
    }
}