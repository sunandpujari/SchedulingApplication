﻿using System.Web.Mvc;
using MedicalAppointmentScheduler.Core.Business;
using MedicalAppointmentScheduler.Core.Data;

namespace MedicalAppointmentScheduler.Controllers
{
    public class AccountController : Controller
    {
        MedicalSchedulerDBEntities dbContext;
        IAccountManager loginManager;
        IAuthentication authenticationHelper;

        public AccountController()
        {
            dbContext = new MedicalSchedulerDBEntities();
            loginManager = new AccountManager(dbContext);
            authenticationHelper = new FormsAuth();

        }

        public AccountController(MedicalSchedulerDBEntities _db , IAccountManager _loginManager, IAuthentication _authenticationHelper)
        {
            MedicalSchedulerDBEntities dbContext =_db ;
            loginManager = _loginManager;
            authenticationHelper = _authenticationHelper;
        }

        //GET: this action is called for all anonymous users to get authenticated
       [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //POST: Authenticate the user and redirect to action based on its role
        [HttpPost]
        public ActionResult Login(UserLogin loginViewModel)
        {
            if (ModelState.IsValid)
            {                            
                int userId = loginManager.ValidateUser(loginViewModel.Email, loginViewModel.Password);
                if (userId != 0)
                {
                    authenticationHelper.SetAuthCookie(loginViewModel.Email);
                    string controllerRole = loginManager.GetUserRole(userId) == null ? "Home" : loginManager.GetUserRole(userId);
                    return RedirectToAction("Index", controllerRole);
                }
                else
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }

            }
            // If we got this far, something failed, redisplay form
            return View(loginViewModel);
        }

        // POST: /Account/LogOff
        [HttpPost]
        [Authorize]
        public ActionResult LogOff()
        {
            authenticationHelper.LogOff();
            return RedirectToAction("Index", "Home");
        }

    }
}
