using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ImageSharingWithUpload.Models;
using System.IO;
using System.Web.Script.Serialization;


namespace ImageSharingWithUpload.Controllers
{
    public class ImagesController : CController
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Upload()
        {
            CheckAda();
            ViewBag.Message = "";
            return View();
        }


        [HttpPost]
        public ActionResult Upload(Image image,
                           HttpPostedFileBase ImageFile)
        {
            //Image image = new Image();
            //image.Id = Id;
            //image.Caption = Caption;
            //image.Description = Description;
            //image.DateTaken = DateTaken;
            CheckAda();

            if (ModelState.IsValid)
            {

                HttpCookie cookie = Request.Cookies.Get("ImageSharing");
                if (cookie != null)
                {
                    image.Userid = cookie["Userid"];

                    //JavaSCript save image info on the server file system
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String jsonData = serializer.Serialize(image);
                    String fileName = Server.MapPath("~/App_Data/Image_Info/" + image.Id + ".js");

                    if (ImageFile != null && ImageFile.ContentLength > 0)
                    {
                        String imgFileName = Server.MapPath("~/Content/Images/" + image.Id + ".jpg");
                        ImageFile.SaveAs(imgFileName);
                        System.IO.File.WriteAllText(fileName, jsonData);
                    }
                    return View("QuerySuccess", image);
                }
                else
                {
                    ViewBag.Message = "Please register before uploading!";
                    return View();
                }

            }
            else
            {
                ViewBag.Message = "Please correct the errors in the form!";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Query()
        {
            CheckAda();
            ViewBag.Message = "";
            return View();
        }


        [HttpGet]
        public ActionResult Details(String Id)
        {
            String fileName = Server.MapPath("~/App_Data/Image_Info/" + Id + ".js");
            CheckAda();
            if (System.IO.File.Exists(fileName))
            {
                String jsonData = System.IO.File.ReadAllText(fileName);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Image image = serializer.Deserialize<Image>(jsonData);

                return View("QuerySuccess", image);

            }

            else
            {
                ViewBag.Message = "Image with identifer " + Id + " not found";
                ViewBag.Id = Id;
                return View("Query");
            }

        }


    }
}
