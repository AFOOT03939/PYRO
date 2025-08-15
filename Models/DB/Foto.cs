using System;
using System.Collections.Generic;

namespace Pyro.Models.DB;

public partial class Foto
{
    public int IdFoto { get; set; }

    public string LinkFoto { get; set; } = null!;

    public DateTime FechaFoto { get; set; }

    public int IdPost { get; set; }

    public virtual Post IdPostNavigation { get; set; } = null!;
}
