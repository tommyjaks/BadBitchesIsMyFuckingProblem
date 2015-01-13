using WebData;
using WebData.Repositories;
using System.Web;
using System.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace Web.Controllers
{
    public class PostsController : ApiController
    {
        private PostRepository PostRepository = new PostRepository();





        //   GET: api/Posts

        public List<string> GetPosts(int userID)
        {


            //// uses linq to get a specific user post (all posts)
            var userPost = PostRepository.GetSpecificUserPosts(userID);

            return userPost;
        }















        [System.Web.Http.HttpPost]
        public IHttpActionResult AddPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = User.Identity.Name;
            post.SenderID = UserRepository.GetUserId(user);
            post.Date = DateTime.Now;
            PostRepository.AddNewPost(post);

            return CreatedAtRoute("DefaultApi", new { id = post.ID }, post);
        }




    }





}