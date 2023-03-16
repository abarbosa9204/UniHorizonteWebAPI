using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class TblEstadoInventario
{
    public long Id { get; set; }

    public Guid RowId { get; set; }

    public string? EstadoNombre { get; set; }

    public bool? Estado { get; set; }

    public string? RowIdUsuarioCreador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? RowIdUsuarioEditor { get; set; }

    public DateTime? FechaEdicion { get; set; }
}
