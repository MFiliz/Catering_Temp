using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catering.Repository.Bases;

namespace Catering.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            var liste = Repositories.AdminRepository.GetGallery();
            return View(liste);
        }
    }
}