using E_Ticaret.Models.Managers;
using E_Ticaret.Models;
using E_Ticaret.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            DatabaseContext db = new DatabaseContext();

            HomePageViewModel model = new HomePageViewModel();

            model.Kullanici = db.Kullanici.ToList();

            return View(model);
        }
    }
}