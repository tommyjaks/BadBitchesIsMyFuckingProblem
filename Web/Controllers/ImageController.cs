using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebData.Repositories;
using Web.Models;
using System.IO;
using System.Security.Claims;
using System.Net;
using Microsoft.Owin.Security;
using System.Web.Security;
using WebData;

namespace Web.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult EditProfile()
        {
            UserRepository rep = new UserRepository();
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);

            return View();
        }


        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (!Directory.Exists(Server.MapPath("~/Images")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Images"));
            }
            try
            {        
                    string filename = System.IO.Path.GetFileName(file.FileName);

                    file.SaveAs(Server.MapPath("~/Images/" + filename));

                    var path = (Server.MapPath("~/Images/" + filename));

                    SaveContent save = new SaveContent();

                    var user = User.Identity.Name;

                    save.ChangeImage(user, filename);

                    ViewBag.Message = "Successfully uploaded picture to: " + path;
            }
            catch
            {
                ViewBag.Message = "Failed to upload picture!";
                //Eventuellt felmeddelande            
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditUser(EditUserModel model)
        {
            UserRepository rep = new UserRepository();
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            ViewData["CheckIfFriendRequest"] = rep.CheckIfUserHaveFriendRequest(userID);
            
            if (ModelState.IsValid)
                {
            try
            {
                    SaveContent save = new SaveContent();

                    UserInfo userinfo = new UserInfo();

                    userinfo.Firstname = model.firstname;
                    userinfo.Lastname = model.lastname;
                    userinfo.City = model.city;
                    userinfo.Email = model.email;
                    userinfo.Password = model.password;
                    userinfo.Username = model.username;
                    userinfo.Searchable = model.searchable;

                    var user = User.Identity.Name;

                    save.UpdateUser(user, userinfo);
                    FormsAuthentication.SetAuthCookie(model.username, false);
            }
            catch
            {
                //Eventuellt felmeddelande            
            }
        }
            

            
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    UserRepository rep = new UserRepository();

                    UserInfo userinfo = new UserInfo();

                    userinfo.Firstname = model.Firstname;
                    userinfo.Lastname = model.Lastname;
                    userinfo.Username = model.Username;
                    userinfo.Gender = model.Gender;
                    userinfo.City = model.City;
                    userinfo.Email = model.Email;
                    userinfo.Age = model.Age;
                    userinfo.Password = model.Password;
                    userinfo.Searchable = model.Searchable;
                    userinfo.img_path = model.img_path;

                    var user = User.Identity.Name;

                    rep.AddUser(userinfo);

                    ViewBag.Message = "Success!, your username is " + model.Username;
                }
                catch
                {
                    ViewBag.Message = "Failed to create user";
                }
            }



            return View();
        }

        [HttpPost]
        public JsonResult CheckIfUsernameExists(string Username)
        {
            var user = UserRepository.DoUserNameExists(Username);

            return Json(user);
        }  
                                          
    }
                                          
    }


