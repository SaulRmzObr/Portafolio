﻿using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
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
            var proyectos = ObtenerProyectos();
            var modelo = new HomeIndexViewModel { Proyectos = proyectos };
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {
                    Titulo = "Api Gmm",
                    Descripcion = "Api Rest para cotizar seguros de Gmm",
                    Link = "https://api.aarco.com.mx/cotizarpaquetesgmm",
                    ImagenURL ="/img/restapigmm.png"

                },
                new Proyecto
                {
                    Titulo = "Landing Gmm",
                    Descripcion = "Sitio web personalizado para agentes donde puedan cotizar seguros de gmm",
                    Link = "https://cotizamaticos.com/lan.gmm/cotizamatico.prueba",
                    ImagenURL ="/img/landinggmm.png"

                },
                new Proyecto
                {
                    Titulo = "Emision Mapfre Gmm",
                    Descripcion = "Modulo del cotizador de gmm donde pueden emitir cotizaciones del producto Pmm de Gmm",
                    Link = "https://uat.cotizamatico.com.mx/login",
                    ImagenURL ="/img/emisiongmm.png"

                }
            };
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