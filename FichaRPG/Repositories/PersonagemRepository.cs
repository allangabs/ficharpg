using Microsoft.EntityFrameworkCore;
using FichaRPG.Data;
using FichaRPG.Models;

namespace FichaRPG.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonagemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Personagem>> ObterTodosAsync()
        {
            return await _context.Personagens
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<List<Personagem>> ObterAtivosAsync()
        {
            return await _context.Personagens
                .Where(p => p.Ativo)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<Personagem?> ObterPorIdAsync(Guid id)
        {
            return await _context.Personagens
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AdicionarAsync(Personagem personagem)
        {
            personagem.Id = Guid.NewGuid();
            await _context.Personagens.AddAsync(personagem);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Personagem personagem)
        {
            _context.Personagens.Update(personagem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var personagem = await ObterPorIdAsync(id);
            if (personagem != null)
            {
                _context.Personagens.Remove(personagem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
