using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases;
using Common.DataContracts;
using DAL.Entities;
using DAL.Repo;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCollection.Data;
using MyCollection.ViewModels;

namespace MyCollection.Controllers
{

    //[Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork iUnitOfWork;
        private readonly UserManager<ApplicationUserEF> _userManager;
        private readonly SignInManager<ApplicationUserEF> _signInManager;

        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUserEF> userManager,
            SignInManager<ApplicationUserEF> signInManager)//, IRepositoryGeneric<AdressEF, int> RepositoryAdress)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            this.iUnitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");

                    return Redirect(loginViewModel.ReturnUrl);
                }
            }

            ModelState.AddModelError("", "Username/password not found");
            return View(loginViewModel);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if ((ModelState.IsValid)/*&&(uc_valideradress())*/)
            {
                var user = new ApplicationUserEF() { UserName = loginViewModel.UserName, Email = loginViewModel.Email, AcceptShared = loginViewModel.AcceptShared };
                var result = await _userManager.CreateAsync(user, loginViewModel.Password);

                if (result.Succeeded)
                {
                    //await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    //option2: var userid=  recherUserNonLoggedById();
                    //var userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var UserRole = new User(user.Id, iUnitOfWork);
                    UserRole.AddNewUserAdress(loginViewModel.ToAdress());

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}