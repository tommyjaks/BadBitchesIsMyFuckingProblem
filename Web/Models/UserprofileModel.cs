using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebData;
using Web.Controllers;

namespace Web.Models
{
    public class UserprofileModel
    {
       public List<UserInfo> User { get; set; }

       public bool CheckIfFriends(int visitedUser)
       {
           UserHomeController c = new UserHomeController();

           return c.CheckIfFriends(visitedUser);
       }

        public bool CheckIfVisitingOwnProfile(string user)
        {
            UserHomeController m = new UserHomeController();

            return m.CheckIfVisitingOwnProfile(user);
        }
    }
}