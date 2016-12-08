using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeAmigos.Interfaces;
using ThreeAmigos.Domain.Account;
using ThreeAmigos.Models;
using ThreeAmigos.Converters;

namespace ThreeAmigos.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationService _authService;
        IAccountService _accountService;

        public AccountController(IAuthenticationService authService, IAccountService accountService)
        {
            _authService = authService;
            _accountService = accountService;
        }

        public ActionResult Index()
        {
            UserViewModel user = GetCurrentUser();

            return View(user);
        }

        public ActionResult History(UserViewModel currentUser = null)
        {
            UserViewModel user = currentUser == null ? GetCurrentUser() : currentUser;

            return View(user);
        }

        public ActionResult LogIn()
        {
            return View("LogIn");
        }

        public ActionResult LogInPost(string username, string password)
        {
            AuthToken token = _authService.AuthenticateUserByUsername(username, password);

            if (token == null)
            {
                TempData["Error"] = "Login Failed";
                return View("LogIn");
            }
            else
            {
                UserViewModel user = Converter.ToUserViewModel(_authService.GetUserByAuthToken(token));

                HttpCookie admingCookie = (user.Roles.Any(x => x.Name == "Admin")) ? new HttpCookie("AdminAccess", "True") : new HttpCookie("AdminAccess", "False");
                HttpCookie cookie = new HttpCookie("AuthToken", token.Token);

                Response.Cookies.Set(cookie);

                return RedirectToAction("Index", "Home", null);
            }
        }


        private UserViewModel GetCurrentUser()
        {
            HttpCookie authToken = Request.Cookies["AuthToken"];
            string token = authToken.Value;
            return (Converter.ToUserViewModel(_authService.GetUserByAuthToken(token)));
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
