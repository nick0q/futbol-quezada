using futbol.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace futbol.Controllers
{
    public class ListarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var jugadoresConEquipos = await _context.DbSetPlayer
                .Select(j => new
                {
                    NombreJugador = j.Nombre,
                    Equipos = _context.DbSetPlayerTeam
                        .Where(pt => pt.PlayerId == j.Id)
                        .Join(_context.DbSetTeam,
                              pt => pt.TeamId,
                              e => e.Id,
                              (pt, e) => e.Nombre)
                        .ToList()
                })
                .ToListAsync();

            ViewBag.JugadoresConEquipos = jugadoresConEquipos;

            return View();
        }
    }
}
