using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
    public partial class UserController : Controller
    {
        private IUnitOfWork _uow;
        private IUsersManager _users;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        private ApplicationDbContext context = new ApplicationDbContext();

        public UserController(IUnitOfWork uow, IUsersManager users)
        {
            _uow = uow;
            _users = users;

        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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
        public virtual ActionResult Index()
        {
            var list = UserManager.Users.ToList();
            return View(list);
        }

        public ActionResult Detail(string id)
        {
            var user = UserManager.FindById(id);
            return View(user);
        }

        public virtual ActionResult ChangePassword(string id)
        {
            var userModel = new UsercredentialsModel();
            userModel.Id = id;
            return View(userModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ChangePassword(UsercredentialsModel usermodel)
        {
            var user = UserManager.FindById(usermodel.Id);

            if (user == null)
            {
                return View("Error");
            }
            user.PasswordHash = UserManager.PasswordHasher.HashPassword(usermodel.Password);
            var result = UserManager.Update(user);
            if (!result.Succeeded)
            {
                //throw exception......
            }
            return RedirectToAction("Index");
        }

        public virtual ActionResult Create()
        {
            ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    //Assign Role to user Here 
                    await this.UserManager.AddToRoleAsync(user.Id, model.Name);
                    //Ends Here

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "User");
                }
                ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        ///[Authorize(Roles = "administrator")]
        public ActionResult UserConfirmationByAdmin(string Id)
        {
            var user = UserManager.FindById(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (user.LockoutEnabled == true)
            {
                ViewBag.isActive = true;
            }
            else
            {
                ViewBag.isActive = false;
            }

            return View(user);
        }
        //[Authorize(Roles = "administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult UserConfirmation(string id)
        {

            var user = UserManager.FindById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            if (user.LockoutEnabled == true)
            {
                user.LockoutEnabled = false;
                UserManager.Update(user);
                return RedirectToAction("index");

            }

            if (user.LockoutEnabled == false)
            {
                user.LockoutEnabled = true;
                UserManager.Update(user);
                return RedirectToAction("index");

            }


            return RedirectToAction("UserConfirmationByAdmin");
        }


        //
        [Authorize(Roles = "administrator")]
        [HttpPost]
        [OutputCache(Location = System.Web.UI.OutputCacheLocation.None, NoStore = true)]
        public ActionResult CheckUserName(string UserName)
        {
            if (0 == context.Users.Where(p => p.UserName == UserName).Count()) return Json(true);
            return Json(false);
        }


        public virtual ActionResult Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "Error", new { area = "" });
            }
            var user = UserManager.FindById(id);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }
            return View(user);

           }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(string id)
        {
            var user = UserManager.FindById(id);
            UserManager.Delete(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }


        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion

    }
}