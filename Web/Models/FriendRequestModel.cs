using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Controllers;

namespace Web.Models
{
    public class FriendRequestModel
    {
        public int senderID { get; set; }
        public int recevierID { get; set; }
        public bool status { get; set; }
        public DateTime date { get; set; }
    }
}