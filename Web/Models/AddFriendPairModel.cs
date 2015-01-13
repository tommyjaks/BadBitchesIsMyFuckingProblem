using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class AddFriendPairModel
    {
        public int UserID { get; set; }
        public int FriendUsername { get; set; }
        public DateTime dateRequested { get; set; }
        public bool Status { get; set; }
    }
}