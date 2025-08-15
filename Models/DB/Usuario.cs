using System;
using System.Collections.Generic;

namespace Pyro.Models.DB;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? ApodoUsuario { get; set; }

    public string ContraUsuario { get; set; } = null!;

    public int? EstadoUsuario { get; set; }

    public DateTime FechaUsuario { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Follow> FollowIdSeguidoNavigations { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowIdSeguidorNavigations { get; set; } = new List<Follow>();

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual ICollection<Membresium> Membresia { get; set; } = new List<Membresium>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Reaccion> Reaccions { get; set; } = new List<Reaccion>();
}
