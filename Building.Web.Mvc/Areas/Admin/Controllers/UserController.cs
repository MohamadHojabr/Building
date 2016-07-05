using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Building.ViewModels.Account;
using DataLayer.Context;
using DomainClasses.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ServiceLayer.IService;

namespace Building.Web.Mvc.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private IUnitOfWork _uow;
        private IUsersManager _users;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public UserController(IUnitOfWork uow, IUsersManager users)
        {
            _uow = uow;
            _users = users;
            //_signInManager = signInManager;
            //_userManager = userManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: Admin/User
        public ActionResult Index()
        {
            var list = _users.GetAllUsers();
            return View(list);
        }

        public ActionResult ChangePassword(string id)
        {
            var userModel = new UsercredentialsModel();
            userModel.Id = id;
            return View(userModel);
        }
        [HttpPost]
        public ActionResult ChangePassword(UsercredentialsModel usermodel)
        {
            var user = _userManager.FindById(usermodel.Id);
            
            if (user == null)
            {
                return View("Error");
            }
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(usermodel.Password);
            var result = _userManager.UpdateAsync(user);
            //if (result.Exception)
            //{
            //    //throw exception......
            //}
            return View();
        }

        //public static bool IsImpersonating(this IPrincipal principal)
        //{
        //    if (principal == null)
        //    {
        //        return false;
        //    }

        //    var claimsPrincipal = principal as ClaimsPrincipal;
        //    if (claimsPrincipal == null)
        //    {
        //        return false;
        //    }


        //    return claimsPrincipal.HasClaim("UserImpersonation", "true");
        //}

        //public static String GetOriginalUsername(this IPrincipal principal)
        //{
        //    if (principal == null)
        //    {
        //        return String.Empty;
        //    }

        //    var claimsPrincipal = principal as ClaimsPrincipal;
        //    if (claimsPrincipal == null)
        //    {
        //        return String.Empty;
        //    }

        //    if (!claimsPrincipal.IsImpersonating())
        //    {
        //        return String.Empty;
        //    }

        //    var originalUsernameClaim = claimsPrincipal.Claims.SingleOrDefault(c => c.Type == "OriginalUsername");

        //    if (originalUsernameClaim == null)
        //    {
        //        return String.Empty;
        //    }

        //    return originalUsernameClaim.Value;
        //}


        public async Task ImpersonateUserAsync(string userName)
        {
            var context = System.Web.HttpContext.Current;

            var originalUsername = context.User.Identity.Name;

            var impersonatedUser = await _userManager.FindByNameAsync(userName);

            var impersonatedIdentity = await _userManager.CreateIdentityAsync(impersonatedUser, DefaultAuthenticationTypes.ApplicationCookie);
            impersonatedIdentity.AddClaim(new Claim("UserImpersonation", "true"));
            impersonatedIdentity.AddClaim(new Claim("OriginalUsername", originalUsername));

            var authenticationManager = context.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, impersonatedIdentity);
        }

        //public async Task RevertImpersonationAsync()
        //{
        //    var context = System.Web.HttpContext.Current;

        //    if (!System.Web.HttpContext.Current.User.IsImpersonating())
        //    {
        //        throw new Exception("Unable to remove impersonation because there is no impersonation");
        //    }


        //    var originalUsername = System.Web.HttpContext.Current.User.GetOriginalUsername();

        //    var originalUser = await _userManager.FindByNameAsync(originalUsername);

        //    var impersonatedIdentity = await _userManager.CreateIdentityAsync(originalUser, DefaultAuthenticationTypes.ApplicationCookie);
        //    var authenticationManager = context.GetOwinContext().Authentication;

        //    authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, impersonatedIdentity);
        //}

    }
}