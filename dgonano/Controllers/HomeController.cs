using dgonano.Models;
using dgonano.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace dgonano.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IntzVajilla _servicioVajilla;
        private readonly IntzMenu _servicioMenu;

        public HomeController(ILogger<HomeController> logger, IntzVajilla ImplVajilla, IntzMenu ImplMenu)
        {
            _logger = logger;
            _servicioVajilla = ImplVajilla;
            _servicioMenu = ImplMenu;
        }

        public IActionResult Index()
        {

            bool salir = false;

            while (!salir)
            {
                // Mostrar el menú
                _servicioMenu.MostrarMenu();
                

                // Obtener la opción del usuario
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                int id, stock;

                // Manejar la opción seleccionada
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Seleccionaste Alta de vajilla");

                        Console.Write("Ingrese el nombre: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Ingrese la descripcion: ");
                        string descripcion = Console.ReadLine();
                        
                        Console.Write("Ingrese la cantidad: ");
                        stock = int.Parse(Console.ReadLine());

                        Vajilla nuevaVajilla = new Vajilla(stock, "Elem-"+nombre, descripcion, nombre);

                        _servicioVajilla.CrearVajilla(nuevaVajilla);

                        break;
                    case "2":
                        Console.WriteLine("Seleccionaste Mostrar stock");

                        _servicioVajilla.MostrarRegistrosDeVajillas();
                        break;
                    case "3":
                        Console.WriteLine("Seleccionaste Crear reserva");

                        Console.Write("Ingrese el id: ");
                        id = int.Parse(Console.ReadLine());

                        Console.Write("Has seleccionado la siguiente Vajilla: ");
                        _servicioVajilla.ObtenerVajillaPorId(id);

                        Vajilla vajillaReserva = _servicioVajilla.ObtenerVajillaPorId(id);

                        Reserva nuevaReserva = new Reserva();

                        nuevaReserva.Idvajillas.Add(vajillaReserva);

                        vajillaReserva.Idreservas.Add(nuevaReserva

                        _servicioVajilla.CrearVajilla(vajillaReserva);

                        break;
                    case "4":
                        Console.WriteLine("Cerrando la aplicación...");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, selecciona una opción del menú (1-6).");
                        break;
                }

                // Pausa para que el usuario pueda ver los resultados antes de limpiar la consola
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); // Limpiar la consola para mostrar el próximo menú
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}