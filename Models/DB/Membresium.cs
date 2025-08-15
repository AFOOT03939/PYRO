using System;
using System.Collections.Generic;

namespace Pyro.Models.DB;

public partial class Membresium
{
    public int IdMember { get; set; }

    public int IdGrupo { get; set; }

    public int IdUsuario { get; set; }

    public DateTime FechaMember { get; set; }

    public virtual Grupo IdGrupoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
