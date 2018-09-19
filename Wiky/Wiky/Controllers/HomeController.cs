using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wiky.Models;

namespace Wiky.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Arts = new ArtEntities2();
            return View(Arts.Article.OrderByDescending(a => a.DateCreate).FirstOrDefault());

        }
        [HttpPost]
        public ActionResult ListeArticle(int searchString)
        {
            var Arts = new ArtEntities2();
          
            return View(Arts.Article.Where(m => m.IDArt == searchString).ToList()); 
        }

       

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ListeArticle()
        {
            var Arts = new ArtEntities2();
            return View(Arts.Article.ToList());

        }
        public ActionResult AddArt()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddArt(Article adtart)//, HttpPostedFileBase Image)
        {
            var Arts = new ArtEntities2();
            if (ModelState.IsValid)
            {

                Arts.Article.Add(adtart);
                Arts.SaveChanges();
            }
                     
            return RedirectToAction("AddArt");

        }

        public ActionResult DeletArt(int IdArt)
        {
            var Arts = new ArtEntities2();
            Article art = Arts.Article.Find(IdArt);
            Arts.Article.Remove(art);
            Arts.SaveChanges();
            return RedirectToAction("ListeArticle");
        }
        public ActionResult UpdatArt(int IdArt)
        {
            var Arts = new ArtEntities2();
            Article art = Arts.Article.Find(IdArt);
            return View(art);
        }
        [HttpPost]
        public ActionResult UpdatArt(Article ArtId)
        {
            var Arts = new ArtEntities2();
            Article art = Arts.Article.Find(ArtId.IDArt);
            art.Theme = ArtId.Theme;
            art.Auteur = ArtId.Auteur;
            art.DateCreate = ArtId.DateCreate;
            art.Contenu = ArtId.Contenu;

            Arts.SaveChanges();
            return RedirectToAction("ListeArticle");

        }
        public ActionResult Detail(int IdArt)
        {
            var Arts = new ArtEntities2();
            Article art = Arts.Article.Find(IdArt);
            ViewBag.IDArt = IdArt;
            return View(art);

        }

        [HttpPost]

        public ActionResult AddComment(Commentaire Com, int IdArt)
        {
            Com.Idart = IdArt;
            var Arts = new ArtEntities2();
            var id = Com.Idart;
            ViewBag.IDArt = id;
            Arts.Commentaire.Add(Com);
            Arts.SaveChanges();
            return PartialView("_PartialView", Arts.Commentaire.Where(m => m.Idart == id).ToList());


        }

        public ActionResult LisComment()
        {
            var Arts = new ArtEntities2();
            return View(Arts.Commentaire.ToList());

        }
        public ActionResult RechercheArt()
        {
            return View();
        }

        public ActionResult DeletCom(int IdCom)
        {
            var Arts = new ArtEntities2();
            Commentaire art = Arts.Commentaire.Find(IdCom);
            var id = art.Idart;
            ViewBag.IDArt = id;
            Arts.Commentaire.Remove(art);
            Arts.SaveChanges();
            return PartialView("_PartialView", Arts.Commentaire.Where(m => m.Idart == id).ToList());
        }

        public ActionResult ChekIfThemeAlreadyExist(string Theme)
        {
            var Arts = new ArtEntities2();
            Article art = Arts.Article.Find(Theme);
            return Json(art.Theme= Theme, JsonRequestBehavior.AllowGet);
        }
    }


}