using Microsoft.AspNetCore.Mvc;
using FichaRPG.Services;

namespace FichaRPG.Controllers
{
    public class OverlayController : Controller
    {
        private readonly PersonagemService _personagemService;

        public OverlayController(PersonagemService personagemService)
        {
            _personagemService = personagemService;
        }

        public IActionResult Index(Guid? id)
        {
            if (id.HasValue)
            {
                var personagem = _personagemService.ObterPorId(id.Value);
                if (personagem == null)
                    return NotFound();
                return View(personagem);
            }
            
            // Se não passar ID, retorna todos os ativos
            var personagens = _personagemService.ObterAtivos();
            return View("IndexAll", personagens);
        }
    }
}
