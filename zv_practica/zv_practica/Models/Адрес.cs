using System;
using System.Collections.Generic;

namespace zv_practica.Models;

public partial class Адрес
{
    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Street { get; set; }

    public string? House { get; set; }

    public string? Appartments { get; set; }

    public string Login { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual Пользователи? Пользователи { get; set; }
}
