using futbol.Data;
using futbol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace futbol.Controllers
{
    public class AsociarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsociarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Jugadores = await _context.DbSetPlayer.ToListAsync();
            ViewBag.Equipos = await _context.DbSetTeam.ToListAsync();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Asociar(int playerId, int teamId)
        {
            var jugador = await _context.DbSetPlayer.FindAsync(playerId);
            var equipo = await _context.DbSetTeam.FindAsync(teamId);

            if (jugador == null || equipo == null)
            {
                TempData["Mensaje"] = "Jugador o equipo no encontrado.";
                return RedirectToAction("Index");
            }

            var existe = await _context.DbSetPlayerTeam
                .AnyAsync(pt => pt.PlayerId == playerId && pt.TeamId == teamId);

            if (!existe)
            {
                var relacion = new PlayerTeam
                {
                    PlayerId = playerId,
                    TeamId = teamId
                };

                _context.DbSetPlayerTeam.Add(relacion);
                await _context.SaveChangesAsync();

                TempData["Mensaje"] = $"El jugador {jugador.Nombre} se asoció al equipo {equipo.Nombre}.";
            }
            else
            {
                TempData["Mensaje"] = $"El jugador {jugador.Nombre} ya está asociado al equipo {equipo.Nombre}.";
            }

            return RedirectToAction("Index");
        }
    }
}
