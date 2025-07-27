using Microsoft.AspNetCore.Mvc;
using SiteAcademia.Data;
using SiteAcademia.Models;

namespace SiteAcademia.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AppDbContext _context;

        public ContatoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enviar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Mensagem enviada com sucesso!";
                return RedirectToAction("Index", "Home");
            }
            TempData["Mensagem"] = "Erro ao enviar mensagem.";
            return RedirectToAction("Index", "Home");
        }
    }
}
