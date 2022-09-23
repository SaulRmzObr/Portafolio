using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos _repositorioProyectos;

        public HomeController(
            IRepositorioProyectos repositorioProyectos
            )
        {
            _repositorioProyectos = repositorioProyectos;
        }

        public IActionResult Index()
        {
            var proyectos = _repositorioProyectos.ObtenerProyectos();
            var modelo = new HomeIndexViewModel 
            {
                Proyectos = proyectos
            };
            return View(modelo);
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