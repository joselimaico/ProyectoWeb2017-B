using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMGOFinal.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            ReservasModelContainer db = new ReservasModelContainer();
            return View(db.ReservaSet);
        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Reserva std)
        {

            if (ModelState.IsValid)
            {
                using (ReservasModelContainer DBContext = new ReservasModelContainer())
                {
                    DBContext.ReservaSet.Add(std);
                    DBContext.SaveChanges();
                }


            }
            return RedirectToAction("Index");

        }



    }
}