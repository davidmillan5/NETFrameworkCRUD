using System;
using System.Collections.Generic;

namespace DOCENTESCRUD.Models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public string? Programa { get; set; }

    public string? NombreModulo { get; set; }

    public int? Creditos { get; set; }

    public long? Precio { get; set; }

    public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>();
}
