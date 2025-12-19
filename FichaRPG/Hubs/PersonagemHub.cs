using Microsoft.AspNetCore.SignalR;
using FichaRPG.Models;

namespace FichaRPG.Hubs
{
    public class PersonagemHub : Hub
    {
        public async Task AtualizarPersonagem(Personagem personagem)
        {
            await Clients.All.SendAsync("PersonagemAtualizado", personagem);
        }
    }
}
