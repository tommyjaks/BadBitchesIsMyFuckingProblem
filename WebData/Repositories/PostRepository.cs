using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WebData.Repositories
{
    public class PostRepository
    {
        public List<Post> GetSpecificUserPosts(string user)
        {
            using (var context = new DejtingEntities())
            {
                var result = context.Posts
                    .Where(x => x.Reciever.Username == user)
                    .OrderByDescending(x => x.Date)
                    .ToList();



                return result;
            }



        }

        public void AddNewPost(Post postinfo)
        {



            using (var context = new DejtingEntities())
            {

                context.Posts.Add(postinfo);
                context.SaveChanges();

            }

        }


    }
}
