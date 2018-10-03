using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catering.Dto;
using Catering.Repository.Bases;

namespace Catering.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        #region GetpPartialViews
        public PartialViewResult GetIletisimPartial()
        {
            var dto = Repositories.IletisimRepository.GetIletisimBilgileri();
            return PartialView("_IletisimPartial", dto);
        }

        public PartialViewResult GetTicketFormPartial()
        {
            return PartialView("_BiletPartial");
        }

        #endregion

        #region Post
        [HttpPost]
        public ActionResult SaveBilet(BiletSaveFormDto dto)
        {

            if (ModelState.IsValid)
            {
                if (Repositories.IletisimRepository.AddBilet(dto))
                {
                    return Json(new { resp = 1 });
                }
                return Json(new { resp = 0 });
            }

            return PartialView("_BiletPartial", dto);

        }

        #endregion
    }
}