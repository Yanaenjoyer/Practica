using System;
using System.Collections.Generic;

namespace zv_practica.Models;

public partial class Категории
{
    public string? CategoryName { get; set; }

    public string? Comments { get; set; }

    public int CategoryId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual Товар? Товар { get; set; }
}
