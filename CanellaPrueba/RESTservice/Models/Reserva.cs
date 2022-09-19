using System;
using System.Collections.Generic;

namespace RESTservice.Models
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public decimal Total { get; set; }
        public int UsuarioIdUsuario { get; set; }
        public int VehiculoIdVehiculo { get; set; }

        public virtual Usuario UsuarioIdUsuarioNavigation { get; set; } = null!;
        public virtual Vehiculo VehiculoIdVehiculoNavigation { get; set; } = null!;
    }
}
