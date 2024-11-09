using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UspgPOS.Models;

namespace UspgPOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["Layout"] = "_LayoutLogged"; // Layout para usuarios logueados
                var detallesEmpleados = new List<DetallesEmpleado>
                {
                    new DetallesEmpleado { Departamento = "IT", NivelExperiencia = 5, CalificacionRendimiento = 8.5, SalarioPromedio = 80000, TasaRotacion = 12.5 },
                    new DetallesEmpleado { Departamento = "RRHH", NivelExperiencia = 3, CalificacionRendimiento = 7.2, SalarioPromedio = 60000, TasaRotacion = 8.3 },
                    new DetallesEmpleado { Departamento = "Marketing", NivelExperiencia = 4, CalificacionRendimiento = 7.8, SalarioPromedio = 70000, TasaRotacion = 10.1 },
                    new DetallesEmpleado { Departamento = "Ventas", NivelExperiencia = 6, CalificacionRendimiento = 8.0, SalarioPromedio = 75000, TasaRotacion = 15.0 }
                };
                return View(detallesEmpleados);
            }
            else
            {
                ViewData["Layout"] = "_Layout"; // Layout para usuarios no logueados
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
