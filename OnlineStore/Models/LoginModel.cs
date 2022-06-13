using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập vào UserName")]
        public string UserName { get; set; } // luu cac gia tri truyen tu view vao
        [Required(ErrorMessage = "Mời nhập vào Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}