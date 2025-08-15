using System;
using System.Collections.Generic;

namespace Pyro.Models.DB;

public partial class Reaccion
{
    public int IdReac { get; set; }

    public DateTime FechaReac { get; set; }

    public int IdUsuario { get; set; }

    public int IdPost { get; set; }

    public virtual Post IdPostNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
