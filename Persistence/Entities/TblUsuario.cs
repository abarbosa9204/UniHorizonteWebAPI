using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class TblUsuario
{
    public long Id { get; set; }

    public Guid RowId { get; set; }

    public string Cedula { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Estado { get; set; }

    public string? RowIdUsuarioCreador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? RowIdUsuarioEditor { get; set; }

    public DateTime? FechaEdicion { get; set; }
}
