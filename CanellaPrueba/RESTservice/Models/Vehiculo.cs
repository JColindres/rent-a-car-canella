using System;
using System.Collections.Generic;

namespace RESTservice.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdVehiculo { get; set; }
        public string Matricula { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Color { get; set; } = null!;
        public decimal Alquiler { get; set; }
        public int GarajeIdGaraje { get; set; }

        public virtual Garaje GarajeIdGarajeNavigation { get; set; } = null!;
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
