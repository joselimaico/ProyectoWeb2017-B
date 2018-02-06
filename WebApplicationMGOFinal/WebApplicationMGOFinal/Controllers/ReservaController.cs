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

        public ActionResult Create(String fecha)
        {
			var std = fecha;
			string [] date_format;
			date_format = fecha.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
			int date = Int32.Parse(date_format[2]);
			int year = Int32.Parse(date_format[3]);
			int month = 0;
			string current_month = date_format[1];
			switch (current_month)
			{
				case "Jan":
					month = 1;
					break;
				case "Feb":
					month = 2;
					break;

			}

			//std = "date:" + date+"month"+month + "year" + year;

			DateTime test = new DateTime(year,month,date);

			ViewData.Add(new KeyValuePair<string, object>("fecha",test));

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

		public ActionResult Calendario()
		{
			return View();
		}


		public JsonResult GetEvents()
		{
			using (ReservasModelContainer db = new ReservasModelContainer())
			{
				var events = db.ReservaSet.ToList();
				return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			}
		}
	}
}