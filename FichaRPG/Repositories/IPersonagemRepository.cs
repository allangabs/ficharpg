using FichaRPG.Models;

namespace FichaRPG.Repositories
{
    public interface IPersonagemRepository
    {
        Task<List<Personagem>> ObterTodosAsync();
        Task<List<Personagem>> ObterAtivosAsync();
        Task<Personagem?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Personagem personagem);
        Task AtualizarAsync(Personagem personagem);
        Task RemoverAsync(Guid id);
    }
}