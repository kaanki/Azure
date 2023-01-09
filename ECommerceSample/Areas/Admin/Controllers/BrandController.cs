using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Common;
using ECommerce.Entity;
using ECommerce.Repository;
using ECommerceSample.Areas.Admin.Models.ResultModel;

namespace ECommerceSample.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {

        // GET: Admin/Brand
        BrandRep br = new BrandRep();
        //Result<List<Brand>> resultList = new Result<List<Brand>>();
        //Result<int> resultint = new Result<int>();
        //Result<Brand> brandResult = new Result<Brand>();
        InstanceResult<Brand> result = new InstanceResult<Brand>();
        
        public ActionResult List()
        {
            result.resultList = br.List();

            return View(result.resultList.ProcessResult);
        }
        public ActionResult AddBrand()
        {
            Brand b = new Brand();
            b.Photo = "DenemeTestDeneme";
            return View(b);
        }
        [ValidateAntiForgeryToken]//veri tabanına dosya/Resim ekletmek için
        [HttpPost]
        public ActionResult AddBrand(Brand model , HttpPostedFileBase photoPath)
        {
            string PhotoName = "";
            if (photoPath.ContentLength>0 & photoPath!=null)
            {
                PhotoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
                string path = Server.MapPath("~/Upload/" + PhotoName);//yol tutar 
                photoPath.SaveAs(path);

            }
            model.Photo = PhotoName;
            if (ModelState.IsValid)//bu yapı tüm properties lerin değerlerini(Atanıp atanmadığını Null olma durumu) kontrol eder
            {
                result.resultint = br.Insert(model);
                if (result.resultint.IsSuccessed)
                {
                    return RedirectToAction("List");                
                 }
                else
                {
                    ViewBag.Mesaj = result.resultint.UserMessage;
                    return View(model);
                }

            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            result.TResult  = br.GetObjById(id);
            return View(result.TResult.ProcessResult);
        }

        [HttpPost]
        public ActionResult Edit(Brand model , HttpPostedFileBase PhotoPath)//action dosyalarla alakalı oldugunu belirtir.
        {
            string PhotoName = model.Photo;
            if (PhotoPath.ContentLength > 0 & PhotoPath != null)
            {
                PhotoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
                string path = Server.MapPath("~/Upload/" + PhotoName);
                PhotoPath.SaveAs(path);
            }
            model.Photo = PhotoName;
            result.resultint = br.Update(model);
            if (result.resultint.IsSuccessed)
            {
                return RedirectToAction("List");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            result.resultint = br.Delete(id);

            return RedirectToAction("List", new { @mesaj = result.resultint.UserMessage });
        }

    }
}