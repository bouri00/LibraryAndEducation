using Admin_pro.Models;
using System.Linq;
using System.Web.Mvc;
using Admin_pro.ViewModels;



namespace Admin_pro.Controllers
{

    public class AuteurController : Controller
    {
        Manage_BooksEntities bd_auteur = new Manage_BooksEntities();
    

        // GET: Auteur
        public ActionResult Auteur()
        {
            var list = bd_auteur.Auteurs.ToList();
            return View(list);
        }




        [HttpGet]
        public ActionResult Create(int? id_Auteur)
        {
            AuteurViewModels atv = new AuteurViewModels();
            if (id_Auteur != null)
            {
                var _modifier = bd_auteur.Auteurs.Where(x => x.id_Auteur == id_Auteur).First();
                atv.id_Auteur = (int)_modifier.id_Auteur;
                atv.nom = _modifier.nom;
                atv.prenom = _modifier.prenom;
                atv.Nationalite = _modifier.Nationalite;
                atv.date_deces = _modifier.date_deces;
            }
            return View(atv);
        }

        [HttpPost]
        public ActionResult Create(AuteurViewModels mol)
        {
            if (mol.id_Auteur != 0)
            {
                var obje = bd_auteur.Auteurs.Where(x => x.id_Auteur == mol.id_Auteur).First();
                obje.id_Auteur = mol.id_Auteur;
                obje.nom = mol.nom;
                obje.prenom = mol.prenom;
                obje.Nationalite = mol.Nationalite;
                obje.date_deces = mol.date_deces;
            }
            else
            {
                bd_auteur.Auteurs.Add(new Models.Auteur

                {
                    id_Auteur = mol.id_Auteur,
                    nom = mol.nom,
                    prenom = mol.prenom,

                    Nationalite = mol.Nationalite,
                    date_deces = mol.date_deces

                });
                
               
            }
            bd_auteur.SaveChanges();
            return RedirectToAction("Auteur");


        }





        [HttpGet]
        public ActionResult Delete(int? id_Auteur)
        {

            AuteurViewModels od = new AuteurViewModels();
            if (id_Auteur != null)
            {

                var _modifier = bd_auteur.Auteurs.Where(x => x.id_Auteur == id_Auteur).First();
                od.id_Auteur = _modifier.id_Auteur;
                od.nom = _modifier.nom;
                od.prenom = od.prenom;
                od.Nationalite = od.Nationalite;
                od.date_deces = od.date_deces;
            }

            return View(od);
        }
        [HttpPost]
        public ActionResult Delete(int? id_Auteur, bool rep)
        {

            if (id_Auteur != null)
            {

                var objet_modifier = bd_auteur.Auteurs.Where(x => x.id_Auteur == id_Auteur).First();
                bd_auteur.Auteurs.Remove(objet_modifier);
                bd_auteur.SaveChanges();


            }

            return RedirectToAction("Auteur");
        }
    }
}

