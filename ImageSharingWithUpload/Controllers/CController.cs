using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageSharingWithUpload.Controllers
{
    public class CController : Controller
    {

        protected void CheckAda()
        {
            HttpCookie cookie = Request.Cookies["ImageSharing"];
			bool isAda = false;

			if (cookie != null) {
                ViewBag.Userid = cookie["Userid"];
                if ("true".Equals((cookie["isAda"])))
                    isAda = true;
                else
                    isAda = false ;
            }

            ViewBag.isAda = isAda;

        }

        
    }
}