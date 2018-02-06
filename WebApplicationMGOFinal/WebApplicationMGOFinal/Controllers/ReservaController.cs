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
		//Editar

		public ActionResult Edit(int idReserva)
		{
			using (ReservasModelContainer db = new ReservasModelContainer())
			{
				var std = (from q in db.ReservaSet
						   where q.IdReserva == idReserva
						   select q).FirstOrDefault();
				return View(std);
			}

		}

		[HttpPost]
		public ActionResult Edit(Reserva reservastd)
		{
			if (ModelState.IsValid)
			{
				using (ReservasModelContainer db = new ReservasModelContainer())
				{

					var u = (from q in db.ReservaSet
							 where q.IdReserva == reservastd.IdReserva
							 select q).FirstOrDefault();
					if (u != null)
					{
						u.NombreCliente = reservastd.NombreCliente;
						u.ApellidoCliente = reservastd.ApellidoCliente;
						u.CorreoCliente = reservastd.CorreoCliente;
						u.EstadoReserva = reservastd.EstadoReserva;
						u.FechaInicio = reservastd.FechaInicio;
						u.FechaFin = reservastd.FechaFin;
						u.InstitucionCliente = reservastd.InstitucionCliente;
						u.TelefonoCliente = reservastd.TelefonoCliente;
					}
					db.SaveChanges();


				}
				return RedirectToAction("Index");
			}
			return View(reservastd);

		}


	}
}