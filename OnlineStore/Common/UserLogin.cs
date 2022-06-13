using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore
{
    [Serializable] // de chuyen doi object ve byte hoac string
    public class UserLogin
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
    }
}