using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases;
using Common.DataContracts;
using Common.MTO;
using DAL.Entities;
using DAL.Repo;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCollection.Data;
using MyCollection.ViewModels;

namespace MyCollection.Controllers
{

    //[Authorize]
    public class AccountController : MicBaseController
    {
        private readonly UserManager<ApplicationUserEF> _userManager;
        private readonly SignInManager<ApplicationUserEF> _signInManager;

        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUserEF> userManager,
            SignInManager<ApplicationUserEF> signInManager) : base(unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

                    userUC.AddNewUserAdress(loginViewModel.ToAdress());

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

        public async Task<IActionResult> Profil()
        {
            var user = await _userManager.GetUserAsync(this.User);

            var adress = userUC.GetAdress();
            var model = new ProfilViewModel()
            {
                AdressUser = adress,
                User = user
            };
            return View(model);
        }
        [HttpPost]
        public  IActionResult Profil(ProfilViewModel profil)
        {

            var a = profil.AdressUser;
            var u = profil.User;
            //a.UserID = u.Id;


            //var user = await _userManager.GetUserAsync(this.User);
           

            //var updated = _userManager.UpdateAsync(u);

            //if (updated.IsCompletedSuccessfully)
            //{
            //    iUnitOfWork.contextDB.Entry(u).State = EntityState.Modified;
            //    iUnitOfWork.contextDB.SaveChangesAsync();
            //}

            userUC.EditProfil(a, u);

            return RedirectToAction("Profil");
        }
            
        




    }
}