using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Repository;
using ECommerce.Common;
using ECommerce.Entity;
using ECommerceSample.Areas.Admin.Models.ResultModel;

using System.Web.SessionState;

namespace ECommerceSample.Areas.Admin.Controllers
{
    public class MemberController : Controller
    {
        MemberRepository mr = new MemberRepository();
        InstanceResult<Member> result = new InstanceResult<Member>();
        // GET: Admin/Member
        public ActionResult List(string mesaj, int? id)
        {
            result.resultList = mr.List();
            
            if (mesaj!=null)
            {
                ViewBag.Mesaj =string.Format("{0} nolu kaydın silme islemi",id,mesaj); 
            }
            else
            {
                ViewBag.Mesaj = "";
            }
            return View(result.resultList.ProcessResult);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(Member model)
        {
            model.RoleId = 1;
            result.resultint = mr.Insert(model);
            if (result.resultint.IsSuccessed)
            {
                return RedirectToAction("List");
            }
            else
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            return View(mr.GetObjById(id).ProcessResult);
        }
        [HttpPost]
        public ActionResult  Edit(Member model)
        {
            result.resultint = mr.Update(model);
            if (result.resultint.IsSuccessed)
            {
                return RedirectToAction("List");
            }
            else
                return View(model);
        }

        public ActionResult Delete(int id)
        {
            result.resultint = mr.Delete(id);
            return RedirectToAction("List", new { @mesaj = result.resultint.UserMessage });
            
        }
       
        [HttpGet]
        public ActionResult EditProfile()
        {
            using (MyECommerceDBEntities1 db = new MyECommerceDBEntities1())
            {
                try
                {

                    if (Request.Cookies["id"] != null)
                    {
                        HttpCookie aCookie = Request.Cookies["id"];
                        int id = Convert.ToInt32(Server.HtmlEncode(aCookie.Value));
                        var current = db.Members.FirstOrDefault(x => x.UserId == id);
                        return View(current);
                    }
                    
                }
                catch (Exception)
                {

                    
                }

                return View();
                
            }
                
            
            
            
        }
        [HttpPost]
        public ActionResult EditProfile(Member model)
        {
            result.resultint = mr.Update(model);
            if (result.resultint.IsSuccessed)
            {
                ViewBag.mesaj = "Basarili";
                    return View();
            }
            else
                return View(model);
        }
    }
}