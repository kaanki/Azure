using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Entity;
using ECommerce.Repository;

namespace ECommerceSample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CommentRep cr = new CommentRep();
        ProductRep pr = new ProductRep();

        public ActionResult Index()
        {
            return View(pr.GetLatestObj(6).ProcessResult);
        }
        public ActionResult Detail(int id)
        {
            Product p = pr.GetObjById(id).ProcessResult;
            return View(p);
        }
        [HttpPost]
        public ActionResult Detail(FormCollection frm, int id)
        {
            
            string isim = frm.Get("isim");
            string telefon = frm.Get("telefon");
            string email = frm.Get("email");
            string yorum = frm.Get("yorum");
            Comment c = new Comment();
            c.CEmail = email;
            c.CName = isim;
            c.Comment1 = yorum;
            c.CPhone =Convert.ToInt32 (telefon);
            c.Product = pr.GetObjById(id).ProcessResult;
            cr.Insert(c);
            ViewBag.basarili = "Yorumunuz Gönderildi";
            return View(c.Product);
        }
        public ActionResult List(Guid? id)
        {
            List<Product> pList = pr.List().ProcessResult.Where(t => t.CategoryId == id).ToList();
            return View(pList);
        }
        public ActionResult ListByBrand(int? id)
        {
            List<Product> pList = pr.List().ProcessResult.Where(t => t.BrandId == id).ToList();
            return View(pList);
        }
        public ActionResult ListAllProduct()
        {
            return View(pr.List().ProcessResult);
        }

        
    }
}