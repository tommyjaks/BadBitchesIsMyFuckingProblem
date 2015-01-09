using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using WebData;

namespace Web.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult UserIndex()
        {
            var model = new UserIndexViewModel();
           
            return View(model);
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            var model = new UserprofileModel();

            var user = User.Identity.Name;

            model.User = WebData.UserRepository.GetLoggedInUser(user);

           

            return View(model);
        }

        public ActionResult FriendsList()
        {
            var model = new UserprofileModel();

            var currentUser = User.Identity.Name;
            var userId = WebData.UserRepository.GetUserId(currentUser);

            model.User = WebData.UserRepository.FriendList(userId);

            return View(model);

        }

        public ActionResult UserProfile(string username)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                var model = new UserprofileModel();

                model.User = WebData.UserRepository.GetLoggedInUser(username);

                return View(model);
            }
            else
            {

                return RedirectToAction("Create", "UserInfo");
            }
        }

        public ActionResult EditProfile()
        {
            return View();
        }
    }
}