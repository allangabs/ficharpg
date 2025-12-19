using Microsoft.AspNetCore.SignalR;
using FichaRPG.Models;

namespace FichaRPG.Hubs
{
    public class DadoHub : Hub
    {
        public async Task EnviarRolagem(RolagemDado rolagem)
        {
            await Clients.All.SendAsync("ReceberRolagem", rolagem);
        }
    }
}
