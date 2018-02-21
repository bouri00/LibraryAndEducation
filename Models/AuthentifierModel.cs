using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_pro.Models
{
    public class AuthentifierModel
    {
        private List<Authentifier> listauthentifier = new List<Authentifier>();

        public AuthentifierModel()
        {
            listauthentifier.Add(new Authentifier { User_Name = "Mustafa", Password_cle = "123456", Roles = new string[] { "superadmin", "admin", "utilisateur" } });
            listauthentifier.Add(new Authentifier { User_Name = "Mohammed", Password_cle = "123", Roles = new string[] { "superadmin", "admin", "utilisateur" } });
            listauthentifier.Add(new Authentifier { User_Name = "Amine", Password_cle = "abc123", Roles = new string[] { "superadmin", "admin", "utilisateur" } });
        }

            public Authentifier find(string User_Name)
        {
            return listauthentifier.Where(acc => acc.User_Name.Equals(User_Name)).FirstOrDefault();
        }

        public Authentifier login(string User_Name, string Password_cle)
        {
            return listauthentifier.Where(acc => acc.User_Name.Equals(User_Name) && acc.Password_cle.Equals(Password_cle)).FirstOrDefault();
        }
    }
        }
    
