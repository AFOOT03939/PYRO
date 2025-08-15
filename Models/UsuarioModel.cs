namespace Pyro.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }

        public string? ApodoUsuario { get; set; }

        public string ContraUsuario { get; set; } = null!;

        public int? EstadoUsuario { get; set; }

        public DateTime FechaUsuario { get; set; }
    }
}
