namespace dgonano.Services
{
    /// <summary>
    /// Clase utilitaria para mostrar un menú en la consola.
    /// </summary>
    public class ImplMenu : IntzMenu
    {
        /// <summary>
        /// Muestra el menú en la consola con varias opciones numeradas.
        /// </summary>
        public void MostrarMenu()
        {
            Console.WriteLine("\n----- Menú -----");
            Console.WriteLine("1. Alta de vajilla");
            Console.WriteLine("2. Mostrar stock");
            Console.WriteLine("3. Crear reserva");
            Console.WriteLine("4. Cerrar la aplicación");
            Console.WriteLine("----------------\n");
        }
    }
}
