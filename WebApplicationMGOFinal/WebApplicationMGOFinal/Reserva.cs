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
    
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public string NombreCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string CorreoCliente { get; set; }
        public int NumeroPersonas { get; set; }
        public string InstitucionCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string EstadoReserva { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public string Color { get; set; }
        public byte IsFullDay { get; set; }
        public string Subject { get; set; }
    }
}