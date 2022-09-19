using System;
using System.Collections.Generic;

namespace RESTservice.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Usuario1 { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public int TuIdTu { get; set; }

        public virtual TipoUsuario TuIdTuNavigation { get; set; } = null!;
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
