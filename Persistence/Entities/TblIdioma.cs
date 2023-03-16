using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class TblIdioma
{
    public long Id { get; set; }

    public Guid RowId { get; set; }

    public string? Idioma { get; set; }

    public bool? Estado { get; set; }

    public string? RowIdUsuarioCreador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? RowIdUsuarioEditor { get; set; }

    public DateTime? FechaEdicion { get; set; }
}
