using FichaRPG.Models;

namespace FichaRPG.Services
{
    public class DadoService
    {
        private readonly Random _random = new();

        public RolagemDado RolarDado(TipoDado tipoDado, int quantidade, Guid? personagemId = null, string? personagemNome = null)
        {
            var rolagem = new RolagemDado
            {
                TipoDado = tipoDado,
                Quantidade = quantidade,
                PersonagemId = personagemId,
                PersonagemNome = personagemNome
            };

            for (int i = 0; i < quantidade; i++)
            {
                int resultado = _random.Next(1, (int)tipoDado + 1);
                rolagem.Resultados.Add(resultado);
            }

            rolagem.MaiorValor = rolagem.Resultados.Max();
            
            return rolagem;
        }
    }
}
