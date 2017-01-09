using E_Ticaret.Models.Managers;
using E_Ticaret.Models;
using E_Ticaret.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Filters;

namespace E_Ticaret.Controllers
{
    [AuthFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {



            DatabaseContext db = new DatabaseContext();

            HomePageViewModel model = new HomePageViewModel();

            if (db.Kullanici != null)
            {
                model.Kullanici = db.Kullanici.ToList();
            }

            return View(model);





        }
    }
}