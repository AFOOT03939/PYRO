namespace Pyro.Models
{
    public class PostModel
    {
        public int IdPost { get; set; }

        public string? DescPost { get; set; }

        public int? EstadoPost { get; set; }

        public DateTime FechaPost { get; set; }

        public int IdUsuario { get; set; }

        public int? IdGrupo { get; set; }
    }
}
