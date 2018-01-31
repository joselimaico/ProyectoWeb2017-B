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
    }
}