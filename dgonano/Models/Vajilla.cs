using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace dgonano.Models
{
    public partial class Vajilla
    {
        public Vajilla()
        {
            Idreservas = new HashSet<Reserva>();
        }

        public int Idvajilla { get; set; }
        public int? Cantidadvajilla { get; set; }
        public string? Codigovajilla { get; set; }
        public string? Descripcionvajilla { get; set; }
        public string? Nombrevajilla { get; set; }

        public virtual ICollection<Reserva> Idreservas { get; set; }

        public Vajilla(int? cantidadvajilla, string? codigovajilla, string? descripcionvajilla, string? nombrevajilla)
        {
            Cantidadvajilla = cantidadvajilla;
            Codigovajilla = codigovajilla;
            Descripcionvajilla = descripcionvajilla;
            Nombrevajilla = nombrevajilla;
        }
    }
}
