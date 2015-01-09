using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebData.Repositories;
using Web.Models;
using System.IO;

namespace Web.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult EditProfile()
        {
            return View();
        }


          [HttpPost]
          public ActionResult Upload(HttpPostedFileBase file, string firstname, string lastname, string city, string email, string password, string username, bool? searchable=null)
          {
              if (!Directory.Exists(Server.MapPath("~/Images")))
              {
                  Directory.CreateDirectory(Server.MapPath("~/Images"));
              }
              try
              {
                  string filename = System.IO.Path.GetFileName(file.FileName);

                  file.SaveAs(Server.MapPath("~/Images/" + filename));
                  string filepathtosave = filename;

                  SaveContent save = new SaveContent();
                  
                  var user = User.Identity.Name;

                  save.UpdateUser(user, filepathtosave, firstname, lastname, city, email, password, username, searchable ?? false);

                  ViewBag.Message = "Success!";
              }

              catch
              {
                  //Eventuellt felmeddelande
                  ViewBag.Message = "Failed!";
              }
              return View();
          }
                                          
    }
}