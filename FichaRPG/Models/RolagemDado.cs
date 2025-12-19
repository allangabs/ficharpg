namespace FichaRPG.Models
{
    public class RolagemDado
    {
        public Guid? PersonagemId { get; set; }
        public string? PersonagemNome { get; set; }
        public TipoDado TipoDado { get; set; }
        public int Quantidade { get; set; }
        public List<int> Resultados { get; set; } = new();
        public int MaiorValor { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;
    }

    public enum TipoDado
    {
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D12 = 12,
        D20 = 20
    }
}
