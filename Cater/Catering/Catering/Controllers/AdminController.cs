using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catering.Repository.Bases;

namespace Catering.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Message()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            var liste = Repositories.AdminRepository.GetGalleryForAdmin();
            return View(liste);
        }

        #region Partial

        public PartialViewResult GetBiletListPartial()
        {
            return PartialView("_BiletListPartial",Repositories.AdminRepository.GetBiletList());
        }

        #endregion

        #region Function
        [HttpGet]
        public ActionResult GetBiletDetail(int id)
        {
            var sonuc = Repositories.AdminRepository.GetBiletDetail(id);
            sonuc.TarihJ = sonuc.Tarih.ToShortDateString();
            return Json(sonuc,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void BiletOku(int id)
        {
            Repositories.AdminRepository.BiletOku(id);
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentType.ToLower() != "image/jpg" ||
                    file.ContentType.ToLower() != "image/jpeg" ||
                    file.ContentType.ToLower() != "image/pjpeg" ||
                    file.ContentType.ToLower() != "image/gif" ||
                    file.ContentType.ToLower() != "image/x-png" ||
                    file.ContentType.ToLower() != "image/png")
                {


                    var dosyaAdi = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                        Server.MapPath("~/images/demo/gallery"), dosyaAdi);
                    // file is uploaded
                    file.SaveAs(path);
                    Repositories.AdminRepository.SaveImage(dosyaAdi);
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Gallery", "Admin");
        }

        public ActionResult ResimSil(int Id)
        {
            Repositories.AdminRepository.ResimSil(Id);
            return null;
        }

        #endregion
    }
}