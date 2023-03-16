using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class TblLibro
{
    public long Id { get; set; }

    public Guid RowId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Contenido { get; set; } = null!;

    public string Titulo { get; set; } = null!;

    public string? Autor { get; set; }

    public string? PrimeraEdicion { get; set; }

    public string? MencionPrimera { get; set; }

    public string Serie { get; set; } = null!;

    public string Editorial { get; set; } = null!;

    public bool? Estado { get; set; }

    public string? RowIdRowIdUsuarioCreador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? RowIdUsuarioEditor { get; set; }

    public DateTime? FechaEdicion { get; set; }
}
