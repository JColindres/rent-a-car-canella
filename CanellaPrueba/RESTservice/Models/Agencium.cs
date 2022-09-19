using System;
using System.Collections.Generic;

namespace RESTservice.Models
{
    public partial class Agencium
    {
        public Agencium()
        {
            Garajes = new HashSet<Garaje>();
        }

        public int IdAgencia { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Garaje> Garajes { get; set; }
    }
}
