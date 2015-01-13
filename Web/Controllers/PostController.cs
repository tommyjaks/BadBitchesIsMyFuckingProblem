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
using WebData;
using WebData.Repositories;
using System.Web;
using System.Net;

namespace Web.Controllers
{
    public class PostsController : ApiController
    {
        private PostRepository PostRepository = new PostRepository();



        //    private DejtingEntities db = new DejtingEntities();

        ////         GET: api/Posts
        //      public IQueryable<Post> GetPosts()
        //        {
        //            return db.Posts;
        //        }

        //     // GET: api/Posts/5
        //        [ResponseType(typeof(Post))]
        //        public IHttpActionResult GetPost(int id)
        //        {
        //            id = 1;
        //            Post post = db.Posts.Find(id);
        //            if (post == null)
        //            {
        //              return NotFound();
        //           }

        //            return Ok(post);
        //        }

        //        // PUT: api/Posts/5
        //        [ResponseType(typeof(void))]
        //        public IHttpActionResult PutPost(int id, Post post)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest(ModelState);
        //            }

        //            if (id != post.ID)
        //            {
        //                return BadRequest();
        //            }

        //            db.Entry(post).State = EntityState.Modified;

        //            try
        //            {
        //                db.SaveChanges();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!PostExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return StatusCode(HttpStatusCode.NoContent);
        //        }

        //        // POST: api/Posts
        //        [ResponseType(typeof(Post))]
        //        public IHttpActionResult PostPost(Post post)
        //        {
        //            if (!ModelState.IsValid)
        //            {
        //                return BadRequest(ModelState);
        //            }

        //            db.Posts.Add(post);
        //            db.SaveChanges();

        //            return CreatedAtRoute("DefaultApi", new { id = post.ID }, post);
        //        }

        //        // DELETE: api/Posts/5
        //        [ResponseType(typeof(Post))]
        //        public IHttpActionResult DeletePost(int id)
        //        {
        //            Post post = db.Posts.Find(id);
        //            if (post == null)
        //            {
        //                return NotFound();
        //            }

        //            db.Posts.Remove(post);
        //            db.SaveChanges();

        //            return Ok(post);
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }

        //        private bool PostExists(int id)
        //        {
        //            return db.Posts.Count(e => e.ID == id) > 0;
        //        }

        //[System.Web.Http.HttpGet]
        //public List<Post> GetPostsForLoggedOnUser()
        //{

        //    var username = User.Identity.Name;
        //    var  loggedOnUserId = UserRepository.GetUserId(username);
        //    var userPost = PostRepository.GetSpecificUserPosts(loggedOnUserId);
        //    return userPost;


        //}

        //[System.Web.Http.HttpGet]
        //public List<Post> GetPostsForOtherUsers()
        //{



        //    var userPost = PostRepository.GetSpecificUserPosts(8);
        //    return userPost;


        //}



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
