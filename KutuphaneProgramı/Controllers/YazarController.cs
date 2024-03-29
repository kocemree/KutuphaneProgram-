﻿using KutuphaneProgrami.Data.Model;
using KutuphaneProgramı.Data.UnitOfWork;
using System.Web.Mvc;

namespace KutuphaneProgramı.Controllers
{
    public class YazarController : Controller
    {
        UnitOfWork unitOfWork;

        public YazarController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            var yazarlar = unitOfWork.GetRepository<Yazar>().GetAll();
            return View(yazarlar);
        }

        [HttpPost]
        public JsonResult EkleJson(string yzrAd)
        {
            Yazar yazar = new Yazar();
            yazar.Ad = yzrAd;
            var eklenenYazar = unitOfWork.GetRepository<Yazar>().Add(yazar);
            unitOfWork.SaveChanges();
            return Json(
                new
                {
                    Result = new
                    {
                        eklenenYazar.Id,
                        eklenenYazar.Ad
                    },
                    JsonRequestBehavior.AllowGet
                }
                );
        }
        [HttpPost]
        public JsonResult SilJson(int yazarId)
        {
            unitOfWork.GetRepository<Yazar>().Delete(yazarId);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            return Json("0");
        }
        [HttpPost]
        public JsonResult GuncelleJson(int yzrId, string yzrAd)
        {
            var yazar = unitOfWork.GetRepository<Yazar>().GetById(yzrId);
            yazar.Ad = yzrAd;
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            return Json("0");
        }
    }
}
