using System;
using System.Collections.Generic;

namespace DOCENTESCRUD.Models;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public DateTime? FechaInicio { get; set; }

    public int? NroEstudiantes { get; set; }

    public string? Jornada { get; set; }

    public int? IdModulo { get; set; }

    public int? IdDocente { get; set; }

    public virtual Docente? IdDocenteNavigation { get; set; }

    public virtual Modulo? IdModuloNavigation { get; set; }
}
