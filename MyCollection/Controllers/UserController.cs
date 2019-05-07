using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases;
using Common.DataContracts;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;


namespace MyCollection.Controllers
{
    public class UserController : Controller
    {

        private IRepositoryGeneric<MovieEF> repository = null;
        private IRepositoryGeneric<AdressEF> adressRepository = null;

        public UserController(IRepositoryGeneric<MovieEF> Repository, IRepositoryGeneric<AdressEF> AdRepository)
        {
            this.repository = Repository;
            this.adressRepository = AdRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMoviesByPostalCode()
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userUC = new User(currentUser, repository, adressRepository);
            var a = userUC.ShowUsersSamePostalMovies();
            return View(a);
        }
    }
}