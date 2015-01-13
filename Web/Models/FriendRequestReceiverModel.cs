using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebData;

namespace Web.Models
{
    public class FriendRequestReceiverModel
    {
        public List<UserInfo> requests { get; set; }
        public int UserID { get; set; }
        public string FriendUsername { get; set; }
        public DateTime dateRequested { get; set; }
        public bool Status { get; set; }
    }
}