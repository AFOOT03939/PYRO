using System;
using System.Collections.Generic;

namespace Pyro.Models.DB;

public partial class Post
{
    public int IdPost { get; set; }

    public string? DescPost { get; set; }

    public int? EstadoPost { get; set; }

    public DateTime FechaPost { get; set; }

    public int IdUsuario { get; set; }

    public int? IdGrupo { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Foto> Fotos { get; set; } = new List<Foto>();

    public virtual Grupo? IdGrupoNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Reaccion> Reaccions { get; set; } = new List<Reaccion>();
}
