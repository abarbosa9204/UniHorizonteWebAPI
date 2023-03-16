using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class TblUsuarioPrograma
{
    public long Id { get; set; }

    public string RowIdUsuario { get; set; } = null!;

    public string RowIdPrograma { get; set; } = null!;

    public bool? Estado { get; set; }

    public string? RowIdUsuarioCreador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? RowIdUsuarioEditor { get; set; }

    public DateTime? FechaEdicion { get; set; }

    public string? Combined { get; set; }
}
