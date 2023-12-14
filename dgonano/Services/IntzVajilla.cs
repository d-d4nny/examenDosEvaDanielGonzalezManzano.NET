using dgonano.Models;

namespace dgonano.Services
{
    public interface IntzVajilla
    {
        public List<Vajilla> ObtenerVajillas();
        public Vajilla ObtenerVajillaPorId(int id);

        public void CrearVajilla(Vajilla vajilla);

        public void ActualizarVajilla(Vajilla vajilla);

        public void EliminarVajilla(Vajilla vajilla);

        public void MostrarRegistrosDeVajillas();
    }
}
