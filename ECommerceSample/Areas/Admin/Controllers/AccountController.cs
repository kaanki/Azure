using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ECommerce.Common;
using ECommerceSample.Areas.Admin.Models.VM;
using ECommerce.Entity;

namespace ECommerceSample.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        //MyECommerceDBEntities db = Tools.GetConection();
        // GET: Admin/Account
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("List", "Category");
            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            
            if (ModelState.IsValid)
            {
                using (MyECommerceDBEntities1 db = new MyECommerceDBEntities1())
                { 
                    var user = db.Members.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                    //Session["id"] = user.UserId;
                    if (user != null)
                    {
                    FormsAuthentication.SetAuthCookie(user.FirstName+" "+user.LastName , true);
                        HttpCookie cook = new HttpCookie("ID");
                        cook.Value = user.UserId.ToString();
                        Response.Cookies.Add(cook);    

                    return RedirectToAction("List","Category",new {@id=user.UserId });
                    }
                }

            }

            ViewBag.Message = "Kullanici Adi veya Parola Yanlis";
            return View();
        }
      
    }
}