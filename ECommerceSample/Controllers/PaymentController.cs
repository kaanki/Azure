using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Entity;
using ECommerce.Repository;
namespace ECommerceSample.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        [HttpGet]
        public ActionResult Pay()
        {
            ViewBag.PaymentTypes = new SelectList(PaymentRep.list(), "PaymentId", "PaymentName");

            return View();
        }
        [HttpPost]
        public ActionResult Pay(Invoice model, List<string> PaymentTypes)
        {
            model.PaymentDate = DateTime.Now;
            foreach (string item in PaymentTypes)
            {
                int PaymentId = Convert.ToInt32(item);
                model.PaymentTypeId = PaymentId;
            }
            model.OrderId = ((Order)Session["Order"]).OrderId;
            InvoiceRep ip = new InvoiceRep();
            if (ip.Insert(model).IsSuccessed)
            {
                Order ord = (Order)Session["Order"];
                if (Request.Cookies["id"] != null)
                {
                    HttpCookie aCookie = Request.Cookies["id"];
                    int id = Convert.ToInt32(Server.HtmlEncode(aCookie.Value));
                    ord.MemberId = id;
                }
                OrderRep ordrep = new OrderRep();
                ord.IsPay = true;
                ordrep.Update(ord);
                return RedirectToAction("PaySucces", "Payment");
            }
            else
            {
                return View(model);
            }


        }
        public ActionResult PaySucces()
        {
            using (MyECommerceDBEntities1 db = new MyECommerceDBEntities1())
            {
                try
                {
                    Order ord = (Order)Session["Order"];
                    Session.Abandon();
                    if (ord.MemberId!=null)
                    {
                        Member m = db.Members.FirstOrDefault(x => x.UserId == ord.MemberId);
                        ViewBag.ad = m.FirstName;
                        ViewBag.soyad = m.LastName;
                    }
                   
                    ViewBag.basarili = "Ödeme Basarili";
                    return View(ord);

                }
                catch (Exception)
                {
                    ViewBag.basarili = "Ödeme Basarısız";
                    return View();

                }

            }

        }
       
    }
}