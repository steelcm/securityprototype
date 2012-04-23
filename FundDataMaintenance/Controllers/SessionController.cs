using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Web.Security;
using FundDataMaintenaceBusiness.Interfaces;
using FundDataMaintenaceBusiness.Models;
using FundDataMaintenance.Models;
using AutoMapper;

namespace FundDataMaintenance.Controllers
{
    public class SessionController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public SessionController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            var viewModel = new SignInVM();
            return View(viewModel);
        }

        [AcceptVerbs(HttpVerbs.Post), ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInVM viewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View("SignIn", viewModel);

            Mapper.CreateMap<SignInVM, UserSM>();
            var user = Mapper.Map<UserSM>(viewModel);
            bool passwordMatches = _authenticationService.PasswordMatches(user, viewModel.Password);
            if(passwordMatches)
            {
                FormsAuthentication.SetAuthCookie(viewModel.Username, viewModel.RememberMe);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Umbrella");
            }
            ModelState.AddModelError("SignIn", "Invalid credentials");
            return View("SignIn", viewModel);
        }

        [HttpGet]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/");
        }

        private void UpdateCookiesAndContext(UserSM user)
        {
            //byte[] cipherText = user.Id.ToString().Encrypt();
            //string base64CipherText = Convert.ToBase64String(cipherText);
            //Response.Cookies.Add(new HttpCookie(GetCookieUserFilterAttribute.UserCookie, base64CipherText));
            //HttpContext.User = new UserViewModel { Email = user.Email, Name = user.Name, IsLoggedIn = true };
        }

    }
}
