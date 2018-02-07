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
			string date = date_format[2];
			string year = date_format[3];
			string month = "";
			
			switch (date_format[1])
			{
				case "Jan":
					month = "01";
					break;
				case "Feb":
					month = "02";
					break;
				case "Mar":
					month = "03";
					break;
				case "Apr":
					month = "04";
					break;
				case "May":
					month = "05";
					break;
				case "June":
					month = "06";
					break;
				case "July":
					month = "07";
					break;
				case "Aug":
					month = "08";
					break;
				case "Sep":
					month = "09";
					break;
				case "Oct":
					month = "10";
					break;
				case "Nov":
					month = "11";
					break;
				case "Dec":
					month = "12";
					break;
			}
			
			string  hora = date_format[4];
			string[] hour_format = hora.Split(':');
			int horas = Int32.Parse(hour_format[0]);
			string minutos = hour_format[1];
			string segundos = hour_format[2];
			//DateTime fechaFin;
			//DateTime test = new DateTime(year,month,date);
			string fecha_inicio="";
			string fecha_final = "";
			fecha_inicio = date + "/" + month + "/" + year + " " + horas + ":" + minutos + ":" + segundos;
			ViewData.Add(new KeyValuePair<string, object>("fechaInicio", fecha_inicio));

			if (minutos.Equals( "00"))
			{
				fecha_final = date + "/" + month + "/" + year + " " + horas + ":" + "30" + ":" + segundos; ;
				ViewData.Add(new KeyValuePair<string, object>("fechaFin", fecha_final));
			}

			else if (minutos.Equals("30"))
			{
				fecha_final= date + "/" + month + "/" + year + " " + (horas+1) + ":" +"00"+ ":" + segundos;
				ViewData.Add(new KeyValuePair<string, object>("fechaFin", fecha_final));
			}
			
			
			





			return View();

        }

		

        [HttpPost]
        public ActionResult Create(Reserva std)
        {

            if (ModelState.IsValid)
            {
                using (ReservasModelContainer DBContext = new ReservasModelContainer())
                {
					std.EstadoReserva = "Reservado";
					std.Color = "red";
					std.IsFullDay = 0;
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

		public ActionResult Agenda(string fecha)
		{
			var std = fecha;
			string[] date_format;
			date_format = fecha.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
			string date = date_format[2].ToString();
			string year = date_format[3].ToString();
			string month = "";

			switch (date_format[1].ToString())
			{
				case "Jan":
					month = "01";
					break;
				case "Feb":
					month = "02";
					break;
				case "Mar":
					month = "03";
					break;
				case "Apr":
					month = "04";
					break;
				case "May":
					month = "05";
					break;
				case "June":
					month = "06";
					break;
				case "July":
					month = "07";
					break;
				case "Aug":
					month = "08";
					break;
				case "Sep":
					month = "09";
					break;
				case "Oct":
					month = "10";
					break;
				case "Nov":
					month = "11";
					break;
				case "Dec":
					month = "12";
					break;
			}
			string test = month + "/" + date + "/" + year;

			ViewData.Add(new KeyValuePair<string, object>("fecha", test));
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