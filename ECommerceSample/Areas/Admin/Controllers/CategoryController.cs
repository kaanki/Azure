using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Repository;
using ECommerce.Common;
using ECommerce.Entity;
using ECommerceSample.Areas.Admin.Models.ResultModel;
using ECommerceSample.Areas.Admin.Models.VM;

namespace ECommerceSample.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        
        CategoryRep cr = new CategoryRep();
        //Result<List<Category>> result = new Result<List<Category>>();
        //Result<int> resultint = new Result<int>();
        //Result<Category> resultt = new Result<Category>();
        InstanceResult<Category> result = new InstanceResult<Category>();
        string Currentid;
        [Authorize]
        public ActionResult List(string mesaj)
        {
            //ViewBag.CurrentUser = User.Identity.Name;
            result.resultList = cr.List();
            ViewBag.Mesaj = mesaj;
            return View(result.resultList.ProcessResult);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            model.CategoryId = Guid.NewGuid();
            result.resultint = cr.Insert(model);
            ViewBag.Mesaj = result.resultint.UserMessage;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            result.TResult = cr.GetObjById(id);
            return View(result.TResult.ProcessResult);
        }
        [HttpPost]
        public ActionResult Edit(Category model)
        {
            result.resultint = cr.Update(model);
            ViewBag.Mesaj = result.resultint.UserMessage;
            return View();
        }
        
        public ActionResult Delete(Guid id)
        {
            result.resultint = cr.Delete(id);
            return RedirectToAction("List", new { @mesaj = result.resultint.UserMessage });
        }
    }
}