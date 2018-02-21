using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Admin_pro.Models
{
    public class Authentifier
    {
        //[Display (Name ="User_Name)]
        public string User_Name
        {
            get;
            set;
        }
        //[Display(Name = "Password_cle)]
        public string Password_cle
        {
            get;
            set;
        }
        public string []Roles
        {
            get;set;
        }
    }

}