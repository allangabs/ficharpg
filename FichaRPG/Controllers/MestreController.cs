using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using FichaRPG.Models;
using FichaRPG.Services;
using FichaRPG.Hubs;

namespace FichaRPG.Controllers
{
    public class MestreController : Controller
    {
        private readonly PersonagemService _personagemService;
        private readonly IHubContext<PersonagemHub> _hubContext;

        public MestreController(PersonagemService personagemService, IHubContext<PersonagemHub> hubContext)
        {
            _personagemService = personagemService;
            _hubContext = hubContext;
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
        public async Task<IActionResult> Criar(Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                _personagemService.Adicionar(personagem);
                
                // Notificar overlay sobre novo personagem
                var personagemCriado = _personagemService.ObterPorId(personagem.Id);
                if (personagemCriado != null)
                {
                    await _hubContext.Clients.All.SendAsync("PersonagemCriado", personagemCriado);
                }
                
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
        public async Task<IActionResult> Editar(Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                _personagemService.Atualizar(personagem);
                
                // Buscar personagem atualizado para enviar via SignalR
                var personagemAtualizado = _personagemService.ObterPorId(personagem.Id);
                if (personagemAtualizado != null)
                {
                    await _hubContext.Clients.All.SendAsync("PersonagemAtualizado", personagemAtualizado);
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        [HttpPost]
        public async Task<IActionResult> AplicarDano(Guid id, int dano)
        {
            _personagemService.AplicarDano(id, dano);
            var personagem = _personagemService.ObterPorId(id);
            if (personagem != null)
            {
                await _hubContext.Clients.All.SendAsync("PersonagemAtualizado", personagem);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Curar(Guid id, int cura)
        {
            _personagemService.Curar(id, cura);
            var personagem = _personagemService.ObterPorId(id);
            if (personagem != null)
            {
                await _hubContext.Clients.All.SendAsync("PersonagemAtualizado", personagem);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AlterarSanidade(Guid id, int valor)
        {
            _personagemService.AlterarSanidade(id, valor);
            var personagem = _personagemService.ObterPorId(id);
            if (personagem != null)
            {
                await _hubContext.Clients.All.SendAsync("PersonagemAtualizado", personagem);
            }
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
