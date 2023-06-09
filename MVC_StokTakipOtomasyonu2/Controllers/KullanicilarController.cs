﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakipOtomasyonu2.Models.Entity;
using System.Web.Security;

namespace MVC_StokTakipOtomasyonu2.Controllers
{
    [AllowAnonymous]
    public class KullanicilarController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        // GET: Kullanicilar
        [HttpGet]
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar k)
        {
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
            if (kullanici != null){
                FormsAuthentication.SetAuthCookie(k.KullaniciAdi,false);
                return RedirectToAction("Index","Home");
            }
            ViewBag.hata = "Kullanıcı adı veya şifre yanlış";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}