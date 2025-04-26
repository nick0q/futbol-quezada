using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using futbol.Models;
using futbol.Data;


namespace futbol.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly ApplicationDbContext _context;

        public PlayerController(ILogger<PlayerController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index");
        }


        [HttpPost]
        public IActionResult RegistrarJugador(Player player){
            if(ModelState.IsValid){
                _context.DbSetPlayer.Add(player);
                _context.SaveChanges();
                ViewData["Message"] = "Se registro al jugador correctamente";
                return View("Index", player);

            }
            return View("Index", player);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}