using System;
using System.Collections.Generic;

namespace Pyro.Models.DB;

public partial class Follow
{
    public int IdFollow { get; set; }

    public int IdSeguidor { get; set; }

    public int IdSeguido { get; set; }

    public DateTime FechaFollow { get; set; }

    public virtual Usuario IdSeguidoNavigation { get; set; } = null!;

    public virtual Usuario IdSeguidorNavigation { get; set; } = null!;
}
