using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebData;
using Web.Models;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Search()
        {
            UserRepository rep = new UserRepository();
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);

            return PartialView("_SearchFormPartial");
        }

        [HttpPost]
        public ActionResult Search(string userName)
        {


            UserRepository rep = new UserRepository();

            if (userName != null)
            {
                try
                {
                    var searchlist = rep.GetSearchedUsername(userName);

                    var model = new SearchModel()
                    {
                        Usernames = searchlist
                    };

                    string currUser = System.Web.HttpContext.Current.User.Identity.Name;
                    int userID = UserRepository.GetUserId(currUser);

                    ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);

                    return PartialView("_SearchResultsPartial", model);
                }
                catch (Exception e)
                {
                    // handle exception
                }
            }
            return PartialView("Error");
        }
    }
}