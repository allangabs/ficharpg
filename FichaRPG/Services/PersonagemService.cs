using FichaRPG.Models;
using FichaRPG.Repositories;

namespace FichaRPG.Services
{
    public class PersonagemService
    {
        private readonly IPersonagemRepository _repository;

        public PersonagemService(IPersonagemRepository repository)
        {
            _repository = repository;
        }

        public List<Personagem> ObterTodos()
        {
            return _repository.ObterTodosAsync().Result;
        }

        public List<Personagem> ObterAtivos()
        {
            return _repository.ObterAtivosAsync().Result;
        }

        public Personagem? ObterPorId(Guid id)
        {
            return _repository.ObterPorIdAsync(id).Result;
        }

        public void Adicionar(Personagem personagem)
        {
            _repository.AdicionarAsync(personagem).Wait();
        }

        public void Atualizar(Personagem personagem)
        {
            _repository.AtualizarAsync(personagem).Wait();
        }

        public void AplicarDano(Guid id, int dano)
        {
            var personagem = ObterPorId(id);
            if (personagem != null)
            {
                personagem.VidaAtual = Math.Max(0, personagem.VidaAtual - dano);
                Atualizar(personagem);
            }
        }

        public void Curar(Guid id, int cura)
        {
            var personagem = ObterPorId(id);
            if (personagem != null)
            {
                personagem.VidaAtual = Math.Min(personagem.VidaMaxima, personagem.VidaAtual + cura);
                Atualizar(personagem);
            }
        }

        public void AlterarSanidade(Guid id, int valor)
        {
            var personagem = ObterPorId(id);
            if (personagem != null)
            {
                personagem.SanidadeAtual = Math.Max(0, Math.Min(personagem.SanidadeMaxima, personagem.SanidadeAtual + valor));
                Atualizar(personagem);
            }
        }

        public void Remover(Guid id)
        {
            _repository.RemoverAsync(id).Wait();
        }
    }
}
