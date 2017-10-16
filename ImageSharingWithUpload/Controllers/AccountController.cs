using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageSharingWithUpload.Controllers
{
	public class AccountController : CController
	{
        public ActionResult Index(){
            return View();
        }
		// GET: Account
		[HttpGet]
		public ActionResult Register()
		{
            HttpCookie cookie = Request.Cookies.Get("ImageSharing");
            if (cookie != null) {
                ViewBag.Userid = cookie["Userid"];
                if ("true".Equals(cookie["ADA"]))
                    ViewBag.ADA = true;
                else
                    ViewBag.ADA = false;
            }
            CheckAda();
			return View();
		}


		[HttpPost]
        public ActionResult Register(String Userid, Boolean ADA){

            HttpCookie cookie = new HttpCookie("ImageSharing");
            cookie.Expires = DateTime.Now.AddMonths(3);
            cookie["Userid"] = Userid;
            cookie["ADA"] = ADA ? "true" : "false";
            Response.Cookies.Add(cookie);

            ViewBag.Userid = Userid;
            //ViewBag.ADA = ADA;
            CheckAda();
            return View("RegisterSuccess"); 
        }
	}
}

