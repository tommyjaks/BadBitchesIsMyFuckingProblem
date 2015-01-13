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
        public List<string> GetSpecificUserPosts(int user)
        {
            using (var context = new DejtingEntities())
            {
                var result = context.Posts
                    .Where(x => x.RecieverID == user)
                    .Select(x => x.Body)
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