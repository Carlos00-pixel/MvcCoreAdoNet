using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VistaMascota()
        {
            Mascota mascota = new Mascota();
            mascota.Nombre = "Animal";
            mascota.Raza = "Tu Mascota";
            mascota.Peso = 22;
            return View(mascota);
        }

    }
}
