using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace WebData
{
    public class UserRepository
    {
        public static List<UserInfo> GetFiveExampleUsers()
        {

            using (var context = new DejtingEntities())
            {
                var result = context.UserInfoes                
                    .OrderBy(x => Guid.NewGuid())
                    .Take(5)
                    .ToList();

                return result;
                //hej
            }

        }

        public void AddUser(UserInfo user)
        {

            using (var context = new DejtingEntities())
            {
                
                context.UserInfoes.Add(user);
                context.SaveChanges();
               
            }
        }
        public void EditUser(UserInfo userinfotoedit)
        {
            using (var context = new DejtingEntities())
            {

                context.Entry(userinfotoedit).State = EntityState.Modified;
                context.SaveChanges();

            }
        }



        
        public static UserInfo TestLogIn(string username, string password)
        {
            using (var context = new DejtingEntities())
            {
                return context.UserInfoes.FirstOrDefault(x =>
                    x.Username.Equals(username) &&
                    x.Password.Equals(password));
            }
        }

        public List<UserInfo> GetSearchedUsername(string query)
        {
            DejtingEntities db = new DejtingEntities();

            var queryz = db.UserInfoes.Where(x => x.Firstname.Contains(query))
            .Except(db.UserInfoes.Where(x => x.Searchable == false));
            return queryz.ToList();
        }

        public static List<UserInfo> GetLoggedInUser(string user)
        {
            using (var context = new DejtingEntities())
            {
                var result = context.UserInfoes
                    
                    .OrderBy(x => x.Firstname)
                    .Where(x => x.Username == user)
                    .ToList();

                return result;
            }
        }

        public static int GetUserId(string username)
        {
            using (var context = new DejtingEntities())
            {
                var result = context.UserInfoes.FirstOrDefault(x => x.Username == username);

                return result != null ? result.ID : -1;
            }
        }

        public static List<UserInfo> FriendList(int userId)
        {

            using (var context = new DejtingEntities())
            {
                return context.Friends
                    .Where(x => x.UserID == userId)
                    .Select(p => p.UserInfo)
                    .ToList();

            }

        }

        public void FriendRequest(Request rq)
        {
            using (var context = new DejtingEntities())
            {
                context.Requests.Add(rq);
                context.SaveChanges();
            }
        }

        public static List<UserInfo> RequestList(int recieverId)
        {
            using (var context = new DejtingEntities())
            {
                var result = context.Requests
                    .Where(x => x.RecieverID == recieverId)
                    .Where(x => x.Status == false)
                    .Join(context.UserInfoes,
                    rq => rq.SenderID,
                    user => user.ID,
                    (rq, user) => new { Request = rq, UserInfo = user})
                    .Select(p => p.UserInfo)
                    .ToList();

                return result;
            }

        }

        public void AddPairToFriendList(Friend friendPair, bool request)
        {
            try
            {
                using (var context = new DejtingEntities())
                {
                    Request rq = context.Requests.SingleOrDefault(x => x.RecieverID == friendPair.UserID && x.SenderID == friendPair.FriendID && x.Status == false);
                    rq.Status = request;

                    if (rq.Status == true)
                    {
                        context.Friends.Add(friendPair);
                    }

                    context.SaveChanges();
                }

            }
            catch
            {
                //Eventuellt felmeddelande
            }
        }

        public void RemoveFromRequests(Friend friendPair)
        {
            try
            {
                using (var context = new DejtingEntities())
                {
                    Request rq = context.Requests.SingleOrDefault(x => x.RecieverID == friendPair.UserID && x.SenderID == friendPair.FriendID && x.Status == false);
                    rq.Status = null;

                    context.SaveChanges();
                }

            }
            catch
            {
                //Eventuellt felmeddelande
            }
        }

        public static bool CheckIfFriends(int ID1, int ID2)
        {
            using (var context = new DejtingEntities())
            {
                Friend fr = context.Friends.SingleOrDefault(x => x.UserID == ID1 && x.FriendID == ID2 || x.UserID == ID2 && x.FriendID == ID1);
                if (fr != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool CheckIfVisitingOwnProfile(string name1, string name2)
        {
            using (var context = new DejtingEntities())
            {
                UserInfo fr = context.UserInfoes.SingleOrDefault(x => x.Username == name1 && x.Username == name2 || x.Username == name2 && x.Username == name1);
                if (fr != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool CheckIfUserHaveFriendRequest(int userID)
        {
            using (var context = new DejtingEntities())
            {
                Request rq = context.Requests.FirstOrDefault(x => x.RecieverID == userID && x.Status == false);

                if (rq != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

