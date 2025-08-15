using System;
using System.Collections.Generic;

namespace Pyro.Models.DB;

public partial class Comentario
{
    public int IdCom { get; set; }

    public string? DescCom { get; set; }

    public DateTime FechaCom { get; set; }

    public int IdPost { get; set; }

    public int IdUsuario { get; set; }

    public virtual Post IdPostNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
