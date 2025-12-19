using Microsoft.AspNetCore.Mvc;
using FichaRPG.Models;
using FichaRPG.Services;

namespace FichaRPG.Controllers
{
    public class MestreController : Controller
    {
        private readonly PersonagemService _personagemService;

        public MestreController(PersonagemService personagemService)
        {
            _personagemService = personagemService;
        }

        public IActionResult Index()
        {
            var personagens = _personagemService.ObterTodos();
            return View(personagens);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                _personagemService.Adicionar(personagem);
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        public IActionResult Editar(Guid id)
        {
            var personagem = _personagemService.ObterPorId(id);
            if (personagem == null)
                return NotFound();
            
            return View(personagem);
        }

        [HttpPost]
        public IActionResult Editar(Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                _personagemService.Atualizar(personagem);
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        [HttpPost]
        public IActionResult AplicarDano(Guid id, int dano)
        {
            _personagemService.AplicarDano(id, dano);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Curar(Guid id, int cura)
        {
            _personagemService.Curar(id, cura);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AlterarSanidade(Guid id, int valor)
        {
            _personagemService.AlterarSanidade(id, valor);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Remover(Guid id)
        {
            _personagemService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult AlternarAtivo(Guid id)
        {
            var personagem = _personagemService.ObterPorId(id);
            if (personagem != null)
            {
                personagem.Ativo = !personagem.Ativo;
                _personagemService.Atualizar(personagem);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
