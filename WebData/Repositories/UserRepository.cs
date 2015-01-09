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

            var queryz = db.UserInfoes.Where(x => x.Firstname.Contains(query));
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
    }
}

