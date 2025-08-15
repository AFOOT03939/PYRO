namespace Pyro.Models
{
    public class FotoModel
    {
        public int IdFoto { get; set; }

        public string LinkFoto { get; set; } = null!;

        public DateTime FechaFoto { get; set; }

        public int IdPost { get; set; }
    }
}
