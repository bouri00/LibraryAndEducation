using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin_pro.Models;


namespace Admin_pro.Models
{
    public class BD_Listes
    {
        public static IEnumerable<SelectListItem> Dropdown_Editeurs
        {
            get
            {
                var bd = new Manage_BooksEntities();
                var query = bd.Editeurs.Select(c => new { id_Editeur = c.id_Editeur, nomE = c.nomE + " " + c.prenomE });
                return new SelectList(query.AsEnumerable(), "id_Editeur","nomE");
            }
        }


        public static IEnumerable<SelectListItem> typeouvrage
        {
            get
            {
                var type = new Manage_BooksEntities();
                var qtype = type.Types.Select(c => new {c.id_type,c.libelle  });
                return new SelectList(qtype.AsEnumerable(), "id_type", "libelle");
            }
        }

        //public static IEnumerable<SelectListItem> prenomEditeurs
        //{
        //    get
        //    {
        //        var b2 = new Manage_BooksEntities();
        //        var q2 = b2.Editeurs.Select(c => new { c.id_Editeur, c.prenomE });
        //        return new SelectList(q2.AsEnumerable(), "id_Editeur", "nomE");
        //    }
        //}



        public static IEnumerable<SelectListItem> Drop_Auteur
        {
            get
            {
                var aut= new Manage_BooksEntities();
                var drop = aut.Auteurs.Select(c => new { c.id_Auteur, c.nom });
                return new SelectList(drop.AsEnumerable(), "id_Auteur", "nom");
            }
        }
        public static IEnumerable<SelectListItem> Drop_PrenomAuteur
        {
            get
            {
                var a1 = new Manage_BooksEntities();
                var b1 = a1.Auteurs.Select(c => new { c.id_Auteur, c.prenom });
                return new SelectList(b1.AsEnumerable(), "id_Auteur", "prenom");
            }
        }
        public static IEnumerable<SelectListItem> Drop_prenomEditeur
        {
            get
            {
                var a2 = new Manage_BooksEntities();
                var b2 = a2.Editeurs.Select(c => new { c.id_Editeur, c.prenomE });
                return new SelectList(b2.AsEnumerable(), "id_Editeur", "prenom");
            }
        }
        public static IEnumerable<SelectListItem> Drop_villedit
        {
            get
            {
                var vil = new Manage_BooksEntities();
                var vil2= vil.Editeurs.Select(c => new { c.id_Editeur, c.ville });
                return new SelectList(vil2.AsEnumerable(), "id_Editeur", "ville");
            }
        }
        public static IEnumerable<SelectListItem> Drop_NatioAut
        {
            get
            {
                var vi = new Manage_BooksEntities();
                var vi2 = vi.Auteurs.Select(c => new { c.id_Auteur, c.Nationalite });
                return new SelectList(vi2.AsEnumerable(), "id_Editeur", "ville");
            }
        }
        public static IEnumerable<SelectListItem> villeetd
        {
            get
            {
                var aa1= new Manage_BooksEntities();
                var aa2= aa1.Etudiants.Select(k => new { k.num_etudiant, k.ville });
                return new SelectList(aa2.AsEnumerable(), "id_Editeur", "ville");
            }
        }




    }


}