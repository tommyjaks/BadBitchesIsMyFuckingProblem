using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebData.Repositories
{
    public class SaveContent
    {
        public void UpdateUser(string currUsername, UserInfo userinfo)
        {
            DejtingEntities db = new DejtingEntities();

            UserInfo user = db.UserInfoes.Single(x => x.Username == currUsername);

            user.img_path = userinfo.img_path;
            user.Firstname = userinfo.Firstname;
            user.Lastname = userinfo.Lastname;
            user.City = userinfo.City;
            user.Email = userinfo.Email;
            user.Password = userinfo.Password;
            user.Username = userinfo.Username;
            user.Searchable = userinfo.Searchable;

            db.SaveChanges();
        }

        public void ChangeImage(string currUsername, string imgpath)
        {
            DejtingEntities db = new DejtingEntities();

            UserInfo user = db.UserInfoes.Single(x => x.Username == currUsername);

            user.img_path = imgpath;

            db.SaveChanges();
        }
    }
}
