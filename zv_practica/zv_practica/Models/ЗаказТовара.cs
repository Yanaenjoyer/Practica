using System;
using System.Collections.Generic;

namespace zv_practica.Models;

public partial class ЗаказТовара
{
    public int OrderNumber { get; set; }

    public int ProductId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Заказ OrderNumberNavigation { get; set; } = null!;

    public virtual Товар Product { get; set; } = null!;
}
