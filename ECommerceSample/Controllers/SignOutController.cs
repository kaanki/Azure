using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ECommerceSample.Areas.Admin.Controllers
{
    public class SignOutController : Controller
    {
        // GET: Admin/SignOut
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/Home/ListAllProduct");
        }
    }
}