using System;
using System.Collections.Generic;

namespace zv_practica.Models;

public partial class ОценкаТовара
{
    public int ProductId { get; set; }

    public string Login { get; set; } = null!;

    public int? Grade { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Пользователи LoginNavigation { get; set; } = null!;

    public virtual Товар Product { get; set; } = null!;
}
