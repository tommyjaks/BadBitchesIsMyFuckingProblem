using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebData.Repositories
{
    public class SaveContent
    {
        public void UpdateUser(string currUsername, string file, string firstname, string lastname, string city, string email, string password, string username, bool searchable)
        {
            DejtingEntities db = new DejtingEntities();

            UserInfo user = db.UserInfoes.Single(x => x.Username == currUsername);

            user.img_path = file;
            user.Firstname = firstname;
            user.Lastname = lastname;
            user.City = city;
            user.Email = email;
            user.Password = password;
            user.Username = username;
            user.Searchable = searchable;

            db.SaveChanges();
        }
    }
}
