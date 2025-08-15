using System;
using System.Collections.Generic;

namespace Pyro.Models.DB;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string? DescGrupo { get; set; }

    public DateTime FechaGrupo { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Membresium> Membresia { get; set; } = new List<Membresium>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
