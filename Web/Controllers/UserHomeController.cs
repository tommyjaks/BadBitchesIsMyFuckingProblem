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

            UserRepository rep = new UserRepository();
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);
           
            return View(model);
        }

        public ActionResult Search()
        {
            UserRepository rep = new UserRepository();
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);

            return View();
        }

        public ActionResult MyProfile()
        {
            var model = new UserprofileModel();

            var user = User.Identity.Name;

            model.User = WebData.UserRepository.GetLoggedInUser(user);

            UserRepository rep = new UserRepository();
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);

            return View(model);
        }

        public ActionResult LayoutPartial()
        {
            return View();
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
            UserRepository rep = new UserRepository();
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);

            return View();
        }

        public ActionResult ChangeToIDAndPassToModel(string senderUsername, string receiverUsername)
        {
            var senderID = UserRepository.GetUserId(senderUsername);

            var receiverID = UserRepository.GetUserId(receiverUsername);

            FriendRequestModel model = new FriendRequestModel();
            model.recevierID = receiverID;
            model.senderID = senderID;
            model.status = false;
            model.date = DateTime.Now;

            AddFriend(model);

            return View();
        }

        public ActionResult AddFriend(FriendRequestModel model)
        {
            UserRepository rep = new UserRepository();

            Request rq = new Request();

            rq.RecieverID = model.recevierID;
            rq.SenderID = model.senderID;
            rq.Status = model.status;
            rq.Date = model.date;

            rep.FriendRequest(rq);

            return View();
        }

        public bool CheckIfFriends(int visitedUser)
        {
            string currUser = System.Web.HttpContext.Current.User.Identity.Name;
            int currUserID = UserRepository.GetUserId(currUser);

            return UserRepository.CheckIfFriends(currUserID, visitedUser);
        }

        public bool CheckIfVisitingOwnProfile(string user)
        {
            string currUser = System.Web.HttpContext.Current.User.Identity.Name;
            return UserRepository.CheckIfVisitingOwnProfile(currUser, user);
        }
        public ActionResult ChangeCulture(string lang)
        {
            var langCookie = new HttpCookie("lang", lang) { HttpOnly = true };
            Response.AppendCookie(langCookie);

            return RedirectToAction("Index", "Home", new { culture = lang });
        }
    }
}