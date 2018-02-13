//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationMGOFinal
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel;
	using System.ComponentModel.DataAnnotations;

	public  class Reserva
    {
        public int IdReserva { get; set; }

		[DisplayName("Nombre"), Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese solo letras.")]
		public string NombreCliente { get; set; }

		[DisplayName("Apellido"), Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese solo letras.")]
		public string ApellidoCliente { get; set; }

		[DisplayName("Teléfono"), Required]
		[RegularExpression(@"^[0-9]+$", ErrorMessage = "Número de teléfono inválido.")]
		public string TelefonoCliente { get; set; }

		[DisplayName("E-mail"), Required]
		[EmailAddress(ErrorMessage = "E-mail inválido.")]
		public string CorreoCliente { get; set; }

		[DisplayName("Número Personas")]
		public int NumeroPersonas { get; set; }

		[DisplayName("Institución")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese solo letras.")]
		public string InstitucionCliente { get; set; }
		
        

		[DisplayName("Fecha Inicio"), Required]
		
		public DateTime FechaInicio { get; set; }

		[DisplayName("Fecha Fin"), Required]
		
		public DateTime FechaFin { get; set; }

		[DisplayName("Comentario"),Required]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese solo letras.")]
		public string Subject { get; set; }

		public string EstadoReserva { get; set; }
		public string Color { get; set; }
		public byte IsFullDay { get; set; }
	}
}
