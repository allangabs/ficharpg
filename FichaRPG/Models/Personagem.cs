namespace FichaRPG.Models
{
    public class Personagem
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Classe { get; set; } = string.Empty;
        public int VidaAtual { get; set; }
        public int VidaMaxima { get; set; }
        public int SanidadeAtual { get; set; }
        public int SanidadeMaxima { get; set; }
        public string? ImagemUrl { get; set; }
        public bool Ativo { get; set; } = true;
        
        // Propriedades calculadas
        public int PorcentagemVida => VidaMaxima > 0 ? (VidaAtual * 100) / VidaMaxima : 0;
        public int PorcentagemSanidade => SanidadeMaxima > 0 ? (SanidadeAtual * 100) / SanidadeMaxima : 0;
    }
}
