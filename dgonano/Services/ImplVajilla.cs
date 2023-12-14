using dgonano.Models;

namespace dgonano.Services
{
    /**
     * Implementación de la interfaz IntzVajilla para operaciones relacionadas con Vajillas.
     */
    public class ImplVajilla : IntzVajilla
    {
        private readonly exaDosContext _contexto; // Contexto de la base de datos

        /**
         * Constructor de la clase ImplVajilla.
         * @param dbContext Contexto de la base de datos.
         */
        public ImplVajilla(exaDosContext dbContext)
        {
            _contexto = dbContext;
        }

        /**
         * Método para actualizar una vajilla en la base de datos.
         * @param vajilla La vajilla a actualizar.
         */
        public void ActualizarVajilla(Vajilla vajilla)
        {
            _contexto.Vajillas.Update(vajilla);
            _contexto.SaveChanges();
        }

        /**
         * Método para crear una nueva vajilla en la base de datos.
         * @param vajilla La nueva vajilla a crear.
         */
        public void CrearVajilla(Vajilla vajilla)
        {
            _contexto.Vajillas.Add(vajilla);
            _contexto.SaveChanges();
        }

        /**
         * Método para eliminar una vajilla de la base de datos.
         * @param vajilla La vajilla a eliminar.
         */
        public void EliminarVajilla(Vajilla vajilla)
        {
            _contexto.Vajillas.Remove(vajilla);
            _contexto.SaveChanges();
        }

        /**
         * Método para obtener una vajilla por su ID.
         * @param id El ID de la vajilla a obtener.
         * @return La vajilla correspondiente al ID proporcionado.
         * @throws Exception Si no se encuentra la vajilla.
         */
        public Vajilla ObtenerVajillaPorId(int id)
        {
            Vajilla vajilla = _contexto.Vajillas.FirstOrDefault(e => e.Idvajilla == id);
            return vajilla == null ? throw new Exception("Vajilla no encontrada") : vajilla;
        }

        /**
         * Método para obtener todas las vajillas de la base de datos.
         * @return Una lista de todas las vajillas existentes.
         */
        public List<Vajilla> ObtenerVajillas()
        {
            return _contexto.Vajillas.ToList();
        }

        /**
         * Método para mostrar los registros de las vajillas en consola.
         */
        public void MostrarRegistrosDeVajillas()
        {
            var vajillas = ObtenerVajillas();

            if (vajillas != null && vajillas.Any())
            {
                Console.WriteLine("Registros de vajillas:");
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("| ID  |      Nombre      | Stock |   Descripcion   |  Codigo  |");
                Console.WriteLine("---------------------------------------------------------------");
                foreach (var vajilla in vajillas)
                {
                    Console.WriteLine($"| {vajilla.Idvajilla,-4} | {vajilla.Nombrevajilla,-11} | {vajilla.Cantidadvajilla,-6} | {vajilla.Descripcionvajilla,-12} | {vajilla.Codigovajilla, -12} |");
                }
                Console.WriteLine("-----------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No hay registros de vajillas.");
            }
        }
    }
}
