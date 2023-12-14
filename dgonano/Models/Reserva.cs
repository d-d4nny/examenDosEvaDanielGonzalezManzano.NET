using System;
using System.Collections.Generic;

namespace dgonano.Models
{
    public partial class Reserva
    {
        public Reserva()
        {
            Idvajillas = new HashSet<Vajilla>();
        }

        public int Idreservas { get; set; }
        public DateTime? Fchreserva { get; set; }

        public virtual ICollection<Vajilla> Idvajillas { get; set; }

        public Reserva(DateTime? fchreserva)
        {
            Fchreserva = fchreserva;
        }
    }
}
