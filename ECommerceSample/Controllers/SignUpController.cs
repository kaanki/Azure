using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Entity;
using ECommerce.Repository;
using ECommerce.Common;

namespace ECommerceSample.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        MemberRepository mr = new MemberRepository();
        MyECommerceDBEntities1 db = Tools.GetConection();
        [HttpGet]
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(Member model)
        {
            ViewBag.Mesaj = mr.Insert(model).UserMessage;
            return View();
        }
    }
}