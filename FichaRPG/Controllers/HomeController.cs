using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using FichaRPG.Models;
using FichaRPG.Services;
using FichaRPG.Hubs;

namespace FichaRPG.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PersonagemService _personagemService;
    private readonly DadoService _dadoService;
    private readonly IHubContext<DadoHub> _hubContext;

    public HomeController(
        ILogger<HomeController> logger,
        PersonagemService personagemService,
        DadoService dadoService,
        IHubContext<DadoHub> hubContext)
    {
        _logger = logger;
        _personagemService = personagemService;
        _dadoService = dadoService;
        _hubContext = hubContext;
    }

    public IActionResult Index()
    {
        ViewBag.Personagens = _personagemService.ObterAtivos();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RolarDado([FromBody] RolarDadoRequest request)
    {
        string? personagemNome = null;
        if (request.PersonagemId.HasValue)
        {
            var personagem = _personagemService.ObterPorId(request.PersonagemId.Value);
            personagemNome = personagem?.Nome;
        }

        var rolagem = _dadoService.RolarDado(request.TipoDado, request.Quantidade, request.PersonagemId, personagemNome);
        
        // Enviar para todos os overlays conectados
        await _hubContext.Clients.All.SendAsync("ReceberRolagem", rolagem);
        
        return Json(rolagem);
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

public class RolarDadoRequest
{
    public TipoDado TipoDado { get; set; }
    public int Quantidade { get; set; }
    public Guid? PersonagemId { get; set; }
}
