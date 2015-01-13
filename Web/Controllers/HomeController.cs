using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebData;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Users = UserRepository.GetFiveExampleUsers();

            UserRepository rep = new UserRepository();
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}