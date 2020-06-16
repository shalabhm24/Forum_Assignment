using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
//using Forum.Models;

namespace Forum.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool IsValid(string _username, string _pwd)
        {
            Entities db = new Entities();
            var loggedInUser = (from userList in db.UserLogins
                         where userList.userName.ToLower() == _username.ToLower() && userList.password.ToLower() == _pwd.ToLower()
                         select new
                         {
                             userList.userId,
                             userList.userName
                         }).ToList().FirstOrDefault();
            if (loggedInUser != null)
            {
                return true;
            }
                return false;
        }
    }
}