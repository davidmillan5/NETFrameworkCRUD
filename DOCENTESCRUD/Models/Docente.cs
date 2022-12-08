using System;
using System.Collections.Generic;

namespace DOCENTESCRUD.Models;

public partial class Docente
{
    public int IdDocente { get; set; }

    public string? Apellidos { get; set; }

    public string? Nombres { get; set; }

    public string? Direccion { get; set; }

    public string? Correo { get; set; }

    public long? Celular { get; set; }

    public string? Municipio { get; set; }

    public virtual ICollection<Grupo> Grupos { get; } = new List<Grupo>();
}
