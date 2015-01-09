using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebData;

namespace Web.Models
{
    public class UserIndexViewModel
    {
        public List<UserInfo> Users { get; set; }
        public List<Post> Post { get; set; }
    }
}