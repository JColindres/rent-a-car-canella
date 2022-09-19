using System;
using System.Collections.Generic;

namespace RESTservice.Models
{
    public partial class Garaje
    {
        public Garaje()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdGaraje { get; set; }
        public string Nombre { get; set; } = null!;
        public int AgenciaIdAgencia { get; set; }

        public virtual Agencium AgenciaIdAgenciaNavigation { get; set; } = null!;
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
